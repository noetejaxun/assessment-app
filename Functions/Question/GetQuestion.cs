using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.Question
{
    public class GetQuestion
    {
        private readonly IQuestionService _questionService;
        public GetQuestion(IQuestionService questionService)
        {
            _questionService = questionService;

        }
        [FunctionName("GetQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "question")] HttpRequest req,
            ILogger log)
        {
            var result = await _questionService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
