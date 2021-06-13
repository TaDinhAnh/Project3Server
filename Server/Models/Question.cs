using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Question
    {
        public Question()
        {
            AnswerQuestions = new HashSet<AnswerQuestion>();
            QuestionSurveys = new HashSet<QuestionSurvey>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual ICollection<QuestionSurvey> QuestionSurveys { get; set; }
    }
}
