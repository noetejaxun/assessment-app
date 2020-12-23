
using System;
using System.Collections.Generic;
using System.Text;

namespace AssessmentApp.Models
{
    public class AssessmentModel
    {
        public Guid AssessmentId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Disabled { get; set; }
        public double TotalPoints { get; set; }

        public ICollection<AssessmentQuestionModel> AssessmentQuestions { get; set; }
    }
}
