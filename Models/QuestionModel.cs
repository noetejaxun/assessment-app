using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentApp.Models
{
    public class QuestionModel
    {
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid QuestionTypeId { get; set; }
        public bool Disabled { get; set; }

        public ICollection<QuestionOptionModel> QuestionOptions { get; set; }
        public ICollection<QuestionTypeModel> QuestionTypes { get; set; }
    }
}
