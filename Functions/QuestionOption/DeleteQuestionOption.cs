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
    public class DeleteQuestionOption
    {
        private readonly IQuestionOptionService _questionOptionService;
        public DeleteQuestionOption(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }
        [FunctionName("DeleteQuestionOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "questionOption")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionOptionModel>(requestBody);

            await _questionOptionService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
