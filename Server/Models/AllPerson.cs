using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class AllPerson
    {
        public AllPerson()
        {
            Seminars = new HashSet<Seminar>();
        }

        public string IdPerson { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string Position { get; set; }
        public string Class { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}
