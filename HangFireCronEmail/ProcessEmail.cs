using Hangfire;
using HangFire.Platform.Common.Data;
using HangFireCronEmail.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace HangFireCronEmail
{

    public class ProcessEmail
    {

        [JobDisplayName("Email process")]
        [AutomaticRetry(Attempts = 1)]
        public string ProcessEmailJob()
        {
            try
            {
                Hangfire_wbc EH_Requeriments = new Hangfire_wbc();
                var hangfireAttributes = EH_Requeriments.Hangfire_Requeriments.Select(x => x).ToList();
                int numDay = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
                EmailDays days = new EmailDays
                {
                    firstDayEmail = int.Parse(hangfireAttributes.Find(x => x.Attribute == "firstDayEmail").Description),
                    secondDayEmail = int.Parse(hangfireAttributes.Find(x => x.Attribute == "secondDayEmail").Description)
                };
                if (!(numDay.Equals(days.firstDayEmail) || numDay.Equals(days.secondDayEmail)))
                {
                    return "Hoy no recibes un correo";
                }

                DateTime lastDateSent = new DateTime();
                try
                {
                    lastDateSent = DateTime.Parse(hangfireAttributes.Find(x => x.Attribute == "LastDateSent").Description);
                }
                catch (Exception e)
                {
                    throw new Exception("Ha ocurrido un problema con el valor de Description del Attribute = LastDateSent en la tabla Hangfire_Requeriments");
                }

                GetCustomerRegisteredRequest requestBody = new GetCustomerRegisteredRequest
                {
                    branchId = null,
                    routeId = null,
                    routes = null,
                    customerName = null,
                    customerId = null, 
                    startDate = lastDateSent,
                    endDate = DateTime.Now,
                    code = null,
                    status = true,
                    start = 0,
                    size = 100
                };

                var client = new RestClient();
                client.BaseUrl = new Uri(ConfigurationManager.AppSettings["APIv2"]);
                var request = new RestRequest("api/consumer/registered", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(requestBody);
                var RestResponse = client.Execute(request);
                var objectCustomer = JsonConvert.DeserializeObject<GetCustomerRegisteredResponse>(RestResponse.Content);
                SendEmail("Correo enviado");

                return "Información procesada";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message != null ? ex.Message : "Exception no identificada");
            }
        }

        private void SendEmail(string message)
        {
            MailMessage mmsg = new MailMessage();

            mmsg.To.Add("ngonzalez@walook.com.mx");
            mmsg.Subject = "Prueba de correo";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mmsg.Body = "<h1>" + message + "</h1>";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;

            mmsg.From = new MailAddress("bepensafullpotentialaws@walook.com.mx");

            SmtpClient client = new SmtpClient();

            client.Credentials = new NetworkCredential("AKIA4VWPJ4MQA5N5FLVM", "BE7TsEtOBV/9SIIFTZ6r9hDvg8HWTWbvyu/dRgXRvenz");

            client.Port = 587;
            client.EnableSsl = true;

            client.Host = "email-smtp.us-east-2.amazonaws.com";

            try
            {
                client.Send(mmsg);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}