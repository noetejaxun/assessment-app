using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace AssessmentApp.Context
{
    public class ModelContextFactory : IDesignTimeDbContextFactory<ModelContext>
    {
        public ModelContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new ModelContext(optionsBuilder.Options);
        }
    }
}
