using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface ISurveyService
    {
        List<Survey> FindAll();
        Survey Find(int idSurvey);
        List<QuestionDTO> AddQues(QuestionSurvey questionSurvey);
        List<QuestionDTO> DelQues(QuestionSurvey questionSurvey);
        string Create(SurveyDTO surveyDTO);
        string Del(int idSurvey);
        string Update(Survey survey);
        List<Survey> FindTop( bool active);
    }
}
