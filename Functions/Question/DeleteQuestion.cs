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

namespace AssessmentApp.Functions.Question
{
    public class DeleteQuestion
    {
        private readonly IQuestionService _questionService;
        public DeleteQuestion(IQuestionService questionService)
        {
            _questionService = questionService;

        }
        [FunctionName("DeleteQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "question")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionModel>(requestBody);

            await _questionService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
