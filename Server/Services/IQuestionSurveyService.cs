using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
   public interface IQuestionSurveyService
    {
        List<QuestionSurvey> Checkquestion(int idsurvey);
        string Create(QuestionSurvey questionSurvey);
    }
}
