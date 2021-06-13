using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class AnswerQuestion
    {
        public int IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public bool? Status { get; set; }

        public virtual Answer IdAnswerNavigation { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
    }
}
