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

namespace AssessmentApp.Functions.QuestionType
{
    public class CreateQuestionType
    {
        private readonly IQuestionTypeService _questionTypeService;
        public CreateQuestionType(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [FunctionName("CreateQuestionType")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "questionType")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionTypeModel>(requestBody);

            var result = await _questionTypeService.CreateAsync(vm);

            return new CreatedResult(result.QuestionTypeId.ToString(), result);
        }
    }
}
