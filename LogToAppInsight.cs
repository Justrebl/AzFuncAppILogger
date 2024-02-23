using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace trash
{
    public class LogToAppInsight
    {
        private readonly ILogger _logger;

        public LogToAppInsight(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LogToAppInsight>();
        }

        [Function("LogToAppInsight")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "LogToAppInsight/{projectName}")] HttpRequestData req,
            string projectName)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            _logger.LogInformation("Here is my Projet Name : {Project}", projectName);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
