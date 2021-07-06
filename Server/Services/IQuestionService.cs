using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface IQuestionService
    {
        List<Question> FindAll();
        List<Question> FindAll2();
        Question Find(int idQuestion);
        List<Question> Create(Question question);
        List<Question> Del(int iduestion);
        Question Update(Question question);
        string CheckCorrect(int question, int ans);
        string CountQuestion(bool count, int id);
        List<Question> FindByActive(bool n, int id);
        List<QuestionDTO> findQuestion(int idSurvey);
    }
}
