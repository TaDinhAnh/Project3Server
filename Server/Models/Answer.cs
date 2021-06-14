using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int? IdQuestion { get; set; }
        public string Answer1 { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Status { get; set; }

        public virtual Question IdQuestionNavigation { get; set; }
    }
}
