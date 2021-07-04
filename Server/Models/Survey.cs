using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Survey
    {
        public Survey()
        {
            QuestionSurveys = new HashSet<QuestionSurvey>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<QuestionSurvey> QuestionSurveys { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
