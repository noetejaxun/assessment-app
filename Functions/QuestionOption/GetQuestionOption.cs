using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.QuestionOption
{
    public class GetQuestionOption
    {
        private readonly IQuestionOptionService _questionOptionService;
        public GetQuestionOption(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }
        [FunctionName("GetQuestionOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "questionOption")] HttpRequest req,
            ILogger log)
        {
            var result = await _questionOptionService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
