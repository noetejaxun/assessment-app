using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentApp.Models
{
    public class QuestionOptionModel
    {
        public Guid QuestionId { get; set; }
        public Guid OptionId { get; set; }
        public bool IsCorrect { get; set; }
        public double Points { get; set; }

        [ForeignKey("OptionId")]
        public OptionModel Option { get; set; }

        [ForeignKey("QuestionId")]
        public QuestionModel Question { get; set; }
    }
}
