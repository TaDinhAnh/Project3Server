using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public class QuestionSurveyServiceImpl : IQuestionSurveyService
    {
        private readonly DatabaseContext db;
        public QuestionSurveyServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public List<QuestionSurvey> Checkquestion(int idsurvey)
        {
            try
            {
                return db.QuestionSurveys.Where(s=> s.IdSurvey == idsurvey).ToList();
            }
            catch 
            {
                return null;
            }       
        }

        public string Create(QuestionSurvey questionSurvey)
        {
            try
            {
                db.QuestionSurveys.Add(questionSurvey);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}