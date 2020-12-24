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

namespace AssessmentApp.Functions.QuestionType
{
    public class UpdateQuestionType
    {
        private readonly IQuestionTypeService _questionTypeService;
        public UpdateQuestionType(IQuestionTypeService questionTypeService)
        {
            _questionTypeService = questionTypeService;
        }

        [FunctionName("UpdateQuestionType")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "questionType")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<QuestionTypeModel>(requestBody);

            await _questionTypeService.UpdateAsync(vm);

            return new OkResult();
        }
    }
}
