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
    public class UpdateQuestion
    {
        private readonly IQuestionService _questionService;
        public UpdateQuestion(IQuestionService questionService)
        {
            _questionService = questionService;

        }
        [FunctionName("UpdateQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "question")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionModel>(requestBody);

            await _questionService.UpdateAsync(vm);

            return new OkResult();
        }
    }
}
