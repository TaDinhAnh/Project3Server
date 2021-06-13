using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class QuestionSurvey
    {
        public int IdQuestion { get; set; }
        public int IdSurvey { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Status { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
        public virtual Survey IdSurveyNavigation { get; set; }
    }
}
