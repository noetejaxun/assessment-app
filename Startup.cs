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
            // builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ModelContext>(
            //     options => options.UseNpgsql(connectionString)); // PosgreSQL
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ModelContext>(
                options => options.UseSqlServer(connectionString)); // SQL Server

            builder.Services.AddTransient<IAssessmentService, AssessmentService>();
            builder.Services.AddTransient<IQuestionTypeService, QuestionTypeService>();
            builder.Services.AddTransient<IOptionService, OptionService>();
            builder.Services.AddTransient<IQuestionService, QuestionService>();
        }
    }
}
