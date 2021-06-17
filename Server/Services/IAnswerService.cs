using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IAnswerService
    {
        List<Answer> FindAll();
        Answer Find(int idAnswer);
        string Create(Answer answer);
        string Del(int idAnswer);
        string Update(Answer answer);
    }
}
