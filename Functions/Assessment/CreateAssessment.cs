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
    public class CreateAssessment
    {
        private readonly IAssessmentService _assessmentService;
        public CreateAssessment(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [FunctionName("CreateAssessment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "assessment")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<AssessmentModel>(requestBody);

            var result = await _assessmentService.CreateAsync(vm);

            return new CreatedResult(result.AssessmentId.ToString(), result);
        }
    }
}
