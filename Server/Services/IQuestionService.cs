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
        List<Question> Create(Question question);
        List<Question> Del(int iduestion);
        Question Update(Question question);
    }
}
