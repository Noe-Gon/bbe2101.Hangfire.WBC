using Hangfire;
using HangFireCronEmail.Services;
using System.Web.Mvc;

namespace HangFireCronEmail.Controllers
{
    public class CustomersController : Controller
    {
        readonly CustomersService customersService = new CustomersService();

        [JobDisplayName("Email sender process")]
        [AutomaticRetry(Attempts = 1)]
        public string EmailProcess()
        {
            /*
            B_CommonCore svrCommon = new B_CommonCore();
            EHangfireRequeriments EH_Requeriments = svrCommon.Get_HangfireRequeriments();
            int pagination = Int32.Parse(ConfigurationManager.AppSettings["CustomerPagination"]);
            int secondsPagination = Int32.Parse(ConfigurationManager.AppSettings["SecondsPagination"]);
            var customers = customersService.GetCustomers(DateTime.Parse(ConfigurationManager.AppSettings["BaseDateToProcessCustomers"]));
            */

            //Debug
            //foreach (var customer in customerPage)
            //{
            //    ECustomer eCustomer = new ECustomer();
            //    eCustomer = MappingEntities(EH_Requeriments, customer);
            //    string jsonSendCustomers = JsonConvert.SerializeObject(eCustomer);
            //    SendInfoToLogisticPlatform(customer.Codigo, jsonSendCustomers, EH_Requeriments.Url_Location);
            //}

            /*
            Parallel.ForEach(customerPage, (customer) =>
            {
                ECustomer eCustomer = new ECustomer();
                eCustomer = MappingEntities(EH_Requeriments, customer);
                string jsonSendCustomers = JsonConvert.SerializeObject(eCustomer);
                BackgroundJob.Enqueue(() => SendInfoToLogisticPlatform(customer.Codigo, jsonSendCustomers, EH_Requeriments.Url_Location));
            });
            Thread.Sleep(secondsPagination * 1000);
            */
            /*
            EH_Requeriments.LastDateModified_Customers = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            svrCommon.Put_HangfireRequeriments(EH_Requeriments, (int)EnumProjects.CronCustomers);
            */
            return "Email enviado";
        }
        /*
        [AutomaticRetry(Attempts = 1)]
        [JobDisplayName("SendEmail")]
        public string SendInfoInEmailToLeader(string emailDestination, string strJson, string url)
        {
            try
            {
                CronController svrCronController = new CronController();
                svrCronController.SendInfoToLogisticPlatform(strJson, url);
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo en enviar el correo a " + emailDestination);
            }
            return "";
        }
        */
    }


}