using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
   public interface IQuestionService
    {
        List<Question> FindAll();
        Question Find(int idQuestion);
        string Create(Question question);
        string Del(int iduestion);
        string Update(Question question);
    }
}
