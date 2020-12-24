using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentApp.Models
{
    public class QuestionModel
    {
        [Key]
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid QuestionTypeId { get; set; }
        public bool Disabled { get; set; }


        public ICollection<QuestionOptionModel> QuestionOptions { get; set; }

        public ICollection<AssessmentQuestionModel> AssessmentQuestions { get; set; }

        [ForeignKey("QuestionTypeId")]
        public QuestionTypeModel QuestionType { get; set; }
    }
}
