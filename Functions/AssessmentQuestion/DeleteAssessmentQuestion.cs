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
    public class DeleteAssessmentQuestion
    {
        private readonly IAssessmentQuestionService _assessmentQuestionService;
        public DeleteAssessmentQuestion(IAssessmentQuestionService assessmentQuestionService)
        {
            _assessmentQuestionService = assessmentQuestionService;
        }

        [FunctionName("DeleteAssessmentQuestion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "assessmentQuestion")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<AssessmentQuestionModel>(requestBody);

            await _assessmentQuestionService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
