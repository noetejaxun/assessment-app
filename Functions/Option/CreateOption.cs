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
    public class CreateOption
    {
        private readonly IOptionService _optionService;
        public CreateOption(IOptionService optionService)
        {
            _optionService = optionService;

        }
        [FunctionName("CreateOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "option")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<OptionModel>(requestBody);

            var result = await _optionService.CreateAsync(vm);

            return new CreatedResult(result.OptionId.ToString(), result);
        }
    }
}
