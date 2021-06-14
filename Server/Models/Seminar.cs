using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Seminar
    {
        public Seminar()
        {
            Imgs = new HashSet<Img>();
            PerformenSeminars = new HashSet<PerformenSeminar>();
            RegisterSeminars = new HashSet<RegisterSeminar>();
        }

        public int Id { get; set; }
        public int? IdTopic { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string Presenters { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public DateTime? Day { get; set; }
        public string Place { get; set; }
        public int? Maximum { get; set; }
        public int? NumberOfParticipants { get; set; }
        public string Descriptoin { get; set; }
        public bool? Status { get; set; }

        public virtual Topic IdTopicNavigation { get; set; }
        public virtual AllPerson PresentersNavigation { get; set; }
        public virtual ICollection<Img> Imgs { get; set; }
        public virtual ICollection<PerformenSeminar> PerformenSeminars { get; set; }
        public virtual ICollection<RegisterSeminar> RegisterSeminars { get; set; }
    }
}
