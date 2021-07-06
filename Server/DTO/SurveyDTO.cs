using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class SurveyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
        public bool Active { get; set; }
        public bool Status { get; set; }
        public List<int> ListQues { get; set; }
    }
}
