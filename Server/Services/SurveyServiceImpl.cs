using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
using Server.DTO;
namespace Server.Services
{
    public class SurveyServiceImpl : ISurveyService
    {
        private readonly DatabaseContext db;
        public SurveyServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(SurveyDTO surveyDTO)
        {
            try
            {
                var idsurvey = db.Surveys.OrderByDescending(e => e.Id).FirstOrDefault();
                var survey = new Survey
                {
                    Id = surveyDTO.Id,
                    Name = surveyDTO.Name,
                    Active = surveyDTO.Active,
                    Description = surveyDTO.Description,
                    Status = surveyDTO.Status,
                    Updated = surveyDTO.Updated
                };
                db.Surveys.Add(survey);
                db.SaveChanges();
                foreach (var item in surveyDTO.ListQues)
                {
                    var sur = new QuestionSurvey
                    {
                        IdQuestion = item,
                        IdSurvey = idsurvey.Id + 1,
                        Updated = DateTime.Now,
                        Status = true
                    };
                    db.QuestionSurveys.Add(sur);
                    db.SaveChanges();
                }
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
                var list = db.QuestionSurveys.Where(e => e.IdSurvey == idSurvey).ToList();
                foreach (var item in list)
                {
                    db.QuestionSurveys.Remove(item);
                }
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
                var sur = db.Surveys.Find(survey.Id);
                sur.Name = survey.Name;
                sur.Description = survey.Description;
                sur.Updated = survey.Updated;
                sur.Active = survey.Active;
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public List<Survey> FindTop( bool active)
        {
            try
            {

                return db.Surveys.Where(s => s.Active == active && s.Status == true &&
                DateTime.Now <= s.Updated.AddDays(5) && s.Updated < DateTime.Now).OrderByDescending(s => s.Id).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<QuestionDTO> AddQues(QuestionSurvey questionSurvey)
        {
            try
            {
                db.QuestionSurveys.Add(questionSurvey);
                db.SaveChanges();
                return db.QuestionSurveys.Where(e => e.IdSurvey == questionSurvey.IdSurvey).Select(e => new QuestionDTO { Id = e.IdQuestion, Question1 = e.IdQuestionNavigation.Question1 }).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<QuestionDTO> DelQues(QuestionSurvey questionSurvey)
        {
            try
            {
                var queSur = db.QuestionSurveys.Where(e => e.IdSurvey == questionSurvey.IdSurvey && e.IdQuestion == questionSurvey.IdQuestion).SingleOrDefault();
                db.QuestionSurveys.Remove(queSur);
                db.SaveChanges();
                return db.QuestionSurveys.Where(e => e.IdSurvey == questionSurvey.IdSurvey).Select(e => new QuestionDTO { Id = e.IdQuestion, Question1 = e.IdQuestionNavigation.Question1 }).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}