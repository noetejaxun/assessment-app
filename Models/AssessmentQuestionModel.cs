﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentApp.Models
{
    public class AssessmentQuestionModel
    {
        public Guid AssessmentId { get; set; }
        public Guid QuestionId { get; set; }
        public double Points { get; set; }

        [ForeignKey("AssessmentId")]
        public AssessmentModel Assessment { get; set; }

        [ForeignKey("QuestionId")]
        public QuestionModel Question { get; set; }
    }
}
