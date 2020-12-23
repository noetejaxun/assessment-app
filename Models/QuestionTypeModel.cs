using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssessmentApp.Models
{
    public class QuestionTypeModel
    {
        [Key]
        public Guid QuestionTypeId { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
