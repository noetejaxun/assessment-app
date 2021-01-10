using System;
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
    public class UpdateQuestionOption
    {
        private readonly IQuestionOptionService _questionOptionService;
        public UpdateQuestionOption(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }

        [FunctionName("UpdateQuestionOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "questionOption")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionOptionModel>(requestBody);

            await _questionOptionService.UpdateAsync(vm);

            return new OkResult();
        }
    }
}
