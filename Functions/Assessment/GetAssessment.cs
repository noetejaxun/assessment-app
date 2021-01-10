using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.Assessment
{

    public class GetAssessment
    {
        private readonly IAssessmentService _assessmentService;
        public GetAssessment(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }
        [FunctionName("GetAssessment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "assessment")] HttpRequest req,
            ILogger log)
        {
            var result = await _assessmentService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
