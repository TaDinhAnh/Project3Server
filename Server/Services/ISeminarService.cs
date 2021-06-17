using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface ISeminarService
    {
        List<Seminar> FindAll();
        Seminar Find(int idSeminar);
        string Create(Seminar seminar);
        string Del(int idSeminar);
        string Update(Seminar seminar);
    }
}
