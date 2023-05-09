using Hangfire.SqlServer;
using Hangfire.WBC.Util;
using HangFireCronEmail;
using HangFireCronEmail.Controllers;
using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;

[assembly: OwinStartup(typeof(Hangfire.WBC.Startup))]

namespace Hangfire.WBC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(ConfigurationManager.AppSettings["HangfireDBConnection"], new SqlServerStorageOptions
                 {
                     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                     QueuePollInterval = TimeSpan.Zero,
                     UseRecommendedIsolationLevel = true,
                     UsePageLocksOnDequeue = true,
                     DisableGlobalLocks = true,
                     PrepareSchemaIfNecessary = true

                 }).WithJobExpirationTimeout(TimeSpan.FromHours(24*1));

            app.UseHangfireDashboard("", new DashboardOptions
            {
                Authorization = new[] { new HFAuthorizationFilter() }
            });

            CustomersController svrCustomers = new CustomersController();

            ProcessEmail processCustomer = new ProcessEmail();

            RecurringJob.AddOrUpdate("Job-EmailStatusRegistroConsumidores", () => processCustomer.ProcessEmailJob(), ConfigurationManager.AppSettings["FrecuencyEmail"]);

            app.UseHangfireServer();
        }
    }
}
