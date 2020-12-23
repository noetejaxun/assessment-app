using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentApp.Models
{
    public class OptionModel
    {
        public Guid OptionId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public bool Disabled { get; set; }

        public ICollection<QuestionOptionModel> QuestionOptions { get; set; }
    }
}
