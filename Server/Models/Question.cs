using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            QuestionSurveys = new HashSet<QuestionSurvey>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QuestionSurvey> QuestionSurveys { get; set; }
    }
}
