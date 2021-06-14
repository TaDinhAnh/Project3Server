using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Account
    {
        public Account()
        {
            RegisterSeminars = new HashSet<RegisterSeminar>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? IdPeople { get; set; }
        public string Class { get; set; }
        public DateTime? Date { get; set; }
        public string Role { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<RegisterSeminar> RegisterSeminars { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
