using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Seminars = new HashSet<Seminar>();
        }

        public int Id { get; set; }
        public string Topic1 { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}
