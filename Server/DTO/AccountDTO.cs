using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Img { get; set; }
        public string Class { get; set; }
        public int? Score { get; set; }
    }
}
