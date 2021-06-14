using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Performer
    {
        public Performer()
        {
            PerformenSeminars = new HashSet<PerformenSeminar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Img { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<PerformenSeminar> PerformenSeminars { get; set; }
    }
}
