using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Services
{
    public class SurveyServiceImpl : ISurveyService
    {
        private readonly DatabaseContext db;
        public SurveyServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Survey survey)
        {
            try
            {
                db.Surveys.Add(survey);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idSurvey)
        {
            try
            {
                db.Surveys.Remove(db.Surveys.Find(idSurvey));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Survey Find(int idSurvey)
        {
            try
            {
                return db.Surveys.Find(idSurvey);
            }
            catch
            {
                return null;
            }
        }

        public List<Survey> FindAll()
        {
            try
            {
                return db.Surveys.ToList();
            }
            catch
            {
                return null;
            }
        }

        public string Update(Survey survey)
        {
            try
            {

                db.Entry(survey).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
