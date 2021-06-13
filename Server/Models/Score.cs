using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Score
    {
        public int? IdAcc { get; set; }
        public int? IdSurvey { get; set; }
        public int? Score1 { get; set; }
        public bool? Status { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual Survey IdSurveyNavigation { get; set; }
    }
}
