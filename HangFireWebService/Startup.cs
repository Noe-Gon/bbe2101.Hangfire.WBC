using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using Hangfire;
using Hangfire.SqlServer;
using Owin;
using HangFireWebService.Services;
using Hangfire.Dashboard;
using HangFireWebService.Util;
using System.Configuration;

namespace HangFireWebService
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {

            //GlobalConfiguration.Configuration
            //    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //    .UseSimpleAssemblyNameTypeSerializer()
            //    .UseRecommendedSerializerSettings()
            //    .UseSqlServerStorage("HangFire_wbc", new SqlServerStorageOptions
            //    {
            //        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //        QueuePollInterval = TimeSpan.Zero,
            //        UseRecommendedIsolationLevel = true,
            //        UsePageLocksOnDequeue = true,
            //        DisableGlobalLocks = true
            //    });

            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new HFAuthorizationFilter() }
            //});

            //app.UseHangfireServer();

            //BinnacleVisitService service = new BinnacleVisitService();
            //RecurringJob.AddOrUpdate(() => service.QueueVisit(), ConfigurationManager.AppSettings["VisitSyncFrecuency"]);
        }


    }
}