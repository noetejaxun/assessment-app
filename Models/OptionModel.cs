using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssessmentApp.Models
{
    public class OptionModel
    {
        [Key]
        public Guid OptionId { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public bool Disabled { get; set; }

        [ForeignKey("OptionId")]
        public QuestionModel Question { get; set; }
    }
}
