using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.AssessmentQuestion
{
    public class GetAssessmentQuestion
    {
        private readonly IAssessmentQuestionService _assessmentQuestionService;
        public GetAssessmentQuestion(IAssessmentQuestionService assessmentQuestionService)
        {
            _assessmentQuestionService = assessmentQuestionService;
        }

        [FunctionName("GetAssessmentQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "assessmentQuestion")] HttpRequest req,
            ILogger log)
        {
            var result = await _assessmentQuestionService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
