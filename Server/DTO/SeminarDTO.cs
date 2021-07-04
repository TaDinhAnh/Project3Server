using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class SeminarDTO
    {
        public int? Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string Presenters { get; set; }
        public string NamePresenters { get; set; }
        public string? TimeStart { get; set; }
        public string? TimeEnd { get; set; }
        public DateTime? Day { get; set; }
        public string Place { get; set; }
        public int? Maximum { get; set; }
        public string Descriptoin { get; set; }
        public bool? Status { get; set; }
    }
}
