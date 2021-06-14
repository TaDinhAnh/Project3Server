using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class RegisterSeminar
    {
        public int IdAcc { get; set; }
        public int IdSeminar { get; set; }
        public bool? Status { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual Seminar IdSeminarNavigation { get; set; }
    }
}
