using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface ISurveyService
    {
        List<Survey> FindAll();
        Survey Find(int idSurvey);
        string Create(Survey survey);
        string Del(int idSurvey);
        string Update(Survey survey);
    }
}
