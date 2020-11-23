using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GetCurrencyRatesFunction
{
    public static class Negotiate
    {
        [FunctionName("Negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "currencyinfo")] SignalRConnectionInfo connectionInfo, ILogger logger)
        {
            logger.LogInformation("Got SignalR connection info {0}", connectionInfo);
            return connectionInfo;
        }
    }
}
