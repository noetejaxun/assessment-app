using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AssessmentApp.Interfaces;

namespace AssessmentApp.Functions.Option
{
    public class GetOptions
    {
        private readonly IOptionService _optionService;
        public GetOptions(IOptionService optionService)
        {
            _optionService = optionService;

        }
        [FunctionName("GetOptions")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "option")] HttpRequest req,
            ILogger log)
        {
            var result = await _optionService.GetAsync();

            return new OkObjectResult(result);
        }
    }
}
