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

namespace AssessmentApp.Functions.Option
{
    public class DeleteOption
    {
        private readonly IOptionService _optionService;
        public DeleteOption(IOptionService optionTypeService)
        {
            _optionService = optionTypeService;
        }

        [FunctionName("DeleteOption")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "option")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var vm = JsonConvert.DeserializeObject<OptionModel>(requestBody);

            await _optionService.DeleteAsync(vm);

            return new OkResult();
        }
    }
}
