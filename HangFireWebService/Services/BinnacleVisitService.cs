using Hangfire;
using HangFireWebService.DB.WBC_DB;
using HangFireWebService.Models.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace HangFireWebService.Services
{

    public class BinnacleVisitService
    {
        WBC_INT_Model db = new WBC_INT_Model();

        [AutomaticRetry(Attempts = 2)]
        public void QueueVisit()
        {
            //Leer fecha delta
            DateTime date = new DateTime();
            var WebServiceUrl = WebApiApplication.URL_WS_WBC_Ope;
            if(WebServiceUrl == "")
                throw new InvalidOperationException("Debe configurar la url del servicio web 'WebApiWBC_Ope' en el archivo de configuración.");

            var deltaDate = db.delta_catalogs.Where(x => x.catalog_name.Equals("visits")).FirstOrDefault();
            if (deltaDate != null)
            {
                date = deltaDate.delta_date;
            }
            else
            {
                throw new InvalidOperationException("El registro para el control delta de las visitas no se encontró en la tabla 'delta_catalogs'");
            }

            var binnacleVisits = GetVisits(date);

            if (binnacleVisits.Any())
            {
                var particion = Partitioner.Create(0, binnacleVisits.Count, 50);
                Parallel.ForEach(particion, (range, loopstate) =>
                {
                    for (int c = range.Item1; c < range.Item2; c++)
                    {
                        BackgroundJob.Enqueue(() => SendVisits(binnacleVisits.ElementAt(c), WebServiceUrl));
                    }
                });

                var newDeltaDate = binnacleVisits.OrderByDescending(x => x.CreatedOn).Select(d => d.CreatedOn).FirstOrDefault();
                deltaDate.delta_date = newDeltaDate;
                db.SaveChanges();
            }
        }

        public List<VisitDto> GetVisits(DateTime fecha)
        {                        
            var visits = db.so_binnacle_visit.Where(x => x.createdon > fecha && (x.status.HasValue ? x.status.Value : false)).ToList();
            var visitsMap = Mapper.Map<List<VisitDto>>(visits);
            return visitsMap;
        }

        [AutomaticRetry(Attempts = 2)]
        public void SendVisits(VisitDto Dto, string Url)
        {                       
            var client = new RestClient(Url);
            var request = new RestRequest("api/Visits", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(Dto);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            IRestResponse response = client.Execute(request);

            if(response.StatusCode != HttpStatusCode.Created)
            {
                if(response.StatusCode.ToString() == "0")
                    throw new InvalidOperationException("No fue posible establecer conexión con el servicio web.");
                else
                    throw new InvalidOperationException(response.Content);
            }

        }
    }
}