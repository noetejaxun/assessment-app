using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.QuestionType
{
    public class GetQuestionType
    {
        private readonly IQuestionTypeService _questionTypeService;
        public GetQuestionType(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [FunctionName("GetQuestionType")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "questionType")] HttpRequest req,
            ILogger log)
        {
            var result = await _questionTypeService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
