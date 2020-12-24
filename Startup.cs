using AssessmentApp.Context;
using AssessmentApp.Interfaces;
using AssessmentApp.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(AssessmentApp.Startup))]
namespace AssessmentApp
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ModelContext>(
                options => options.UseNpgsql(connectionString));

            builder.Services.AddTransient<IAssessmentService, AssessmentService>();
            builder.Services.AddTransient<IQuestionTypeService, QuestionTypeService>();
        }
    }
}
