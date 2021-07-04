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
        List<Answer> Create(Answer answer);
        List<Answer> Del(int idAnswer, int idQues);
        List<Answer> Update(Answer answer);
    }
}
