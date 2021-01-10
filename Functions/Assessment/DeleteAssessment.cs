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
    public class DeleteAssessment
    {
        private readonly IAssessmentService _assessmentService;
        public DeleteAssessment(IAssessmentService assessmentService)
        {
            _assessmentService = assessmentService;
        }

        [FunctionName("DeleteAssessment")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "assessment")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<AssessmentModel>(requestBody);

            await _assessmentService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
