using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerQuestions = new HashSet<AnswerQuestion>();
        }

        public int Id { get; set; }
        public string Answer1 { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
