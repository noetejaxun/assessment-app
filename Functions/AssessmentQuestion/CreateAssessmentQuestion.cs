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

namespace AssessmentApp.Functions.AssessmentQuestion
{
    public class CreateAssessmentQuestion
    {
        private readonly IAssessmentQuestionService _assessmentQuestionService;
        public CreateAssessmentQuestion(IAssessmentQuestionService assessmentQuestionService)
        {
            _assessmentQuestionService = assessmentQuestionService;
        }

        [FunctionName("CreateAssessmentQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "assessmentQuestion")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<AssessmentQuestionModel>(requestBody);

            var result = await _assessmentQuestionService.CreateAsync(vm);

            return new CreatedResult(result.AssessmentId.ToString(), result);
        }
    }
}
