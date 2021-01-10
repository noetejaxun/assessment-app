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

namespace AssessmentApp.Functions.Option
{
    public class UpdateOption
    {
        private readonly IOptionService _optionService;
        public UpdateOption(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [FunctionName("UpdateOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "option")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<OptionModel>(requestBody);

            await _optionService.UpdateAsync(vm);
            log.LogDebug("UpdateQuestionType function correctly executed.");
            return new OkResult();
        }
    }
}
