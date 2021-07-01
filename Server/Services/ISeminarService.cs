using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface ISeminarService
    {
        List<Seminar> FindAll();
        List<SeminarDTO> FindAll2();
        List<SeminarDTO> RecentSeminar(int n);
        Seminar Find(int idSeminar);
        SeminarDTO FindDTO(int idSeminar);
        string Create(Seminar seminar);
        List<SeminarDTO> Del(int idSeminar);
        string Update(SeminarDTO seminarDTO);
        Seminar UpdatePre(int idSeminar, string idPrecenter);
        Seminar DelPerforment(int idSeminar, int idPerforment);
        Seminar AddPerforment(PerformenSeminar performenSeminar);
     
    }
}
