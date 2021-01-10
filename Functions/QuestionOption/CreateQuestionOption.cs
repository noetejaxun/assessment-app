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

namespace AssessmentApp.Functions.QuestionOption
{
    public class CreateQuestionOption
    {
        private readonly IQuestionOptionService _questionOptionService;
        public CreateQuestionOption(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }
        [FunctionName("CreateQuestionOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "questionOption")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionOptionModel>(requestBody);

            var result = await _questionOptionService.CreateAsync(vm);

            return new CreatedResult(result.QuestionId.ToString(), result);
        }
    }
}
