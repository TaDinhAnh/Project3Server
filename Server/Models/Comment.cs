using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Massage { get; set; }
        public int? IdAcc { get; set; }

        public virtual Account IdAccNavigation { get; set; }
    }
}
