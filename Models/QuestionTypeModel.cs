using System;
using System.Collections.Generic;

namespace AssessmentApp.Models
{
    public class QuestionTypeModel
    {
        public Guid QuestionTypeId { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
