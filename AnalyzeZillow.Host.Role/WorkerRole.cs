using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using AnalyzeZillow.Core.SQL;
using AnalyzeZillow.Core;

namespace AnalyzeZillow.Host.Role
{
    public class WorkerRole : RoleEntryPoint
    {
        //Generated Code
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        
        public override void Run()
        {
            Trace.TraceInformation("AnalyzeZillow.Host.Role is running");
            Trace.TraceInformation("Working");
            //DO Work
            var instanceIdSplit = RoleEnvironment.CurrentRoleInstance.Id.Split('_');
            var roleNumberString = instanceIdSplit[instanceIdSplit.Length - 1];
            int roleNumber;
            int.TryParse(roleNumberString, out roleNumber);
            //82300179 <- Home in Pompano Beach
            if(roleNumber == 0)
            {
                WorkerRole.DoWork(82300178);
            }
            else
            {
                WorkerRole.DoWork(82300179);
            }

        }

        public static async void DoWork(int i)
        {
            
            bool done = false;
            ZillowDataRepository zRepo = new ZillowDataRepository();
            while (!done)
            {
                try
                {
                    Home h = Brains.Brains.GetHome(i);
                    await zRepo.SaveSingle(h);
                    i += 2;
                }
                catch (Exception e)
                {
                    //done = true;
                    i += 2;
                }

            }
        }
        //Generated Code
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("AnalyzeZillow.Host.Role has been started");

            return result;
        }
        //Generated Code
        public override void OnStop()
        {
            Trace.TraceInformation("AnalyzeZillow.Host.Role is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("AnalyzeZillow.Host.Role has stopped");
        }
    }
}
