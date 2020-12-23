using AssessmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentApp.Context
{
    public class DemoContext : DbContext
    {
        public DbSet<AssessmentModel> Assessments { get; set; }
        public DbSet<AssessmentQuestionModel> AssessmentQuestions { get; set; }
        public DbSet<OptionModel> Options { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<QuestionOptionModel> QuestionOptions { get; set; }
        public DbSet<QuestionTypeModel> QuestionTypes { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
    }
}
