using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class PerformenSeminar
    {
        public int? IdPerforment { get; set; }
        public int? IdSeminar { get; set; }
        public bool? Status { get; set; }

        public virtual Performer IdPerformentNavigation { get; set; }
        public virtual Seminar IdSeminarNavigation { get; set; }
    }
}
