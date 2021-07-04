using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            RegisterSeminars = new HashSet<RegisterSeminar>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Img { get; set; }
        public string IdPeople { get; set; }
        public string Class { get; set; }
        public DateTime? Date { get; set; }
        public string Role { get; set; }
        public bool? Status { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<RegisterSeminar> RegisterSeminars { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
