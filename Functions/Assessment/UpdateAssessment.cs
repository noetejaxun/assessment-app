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
using AssessmentApp.Models;

namespace AssessmentApp.Functions.Assessment
{
    public class UpdateAssessment
    {
        private readonly IAssessmentService _assessmentService;
        public UpdateAssessment(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [FunctionName("UpdateAssessment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "assessment")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<AssessmentModel>(requestBody);

            await _assessmentService.UpdateAsync(vm);

            return new OkResult();
        }
    }
}
