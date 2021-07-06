using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public class QuestionServiceImpl : IQuestionService
    {
        private readonly DatabaseContext db;
        public QuestionServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public List<Question> Create(Question question)
        {
            try
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return db.Questions.Select(e => new Question { Id = e.Id, Question1 = e.Question1, Updated = e.Updated, Status = e.Status }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Question> Del(int idQuestion)
        {
            try
            {
                db.Questions.Find(idQuestion).Status = false;
                db.SaveChanges();
                return db.Questions.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Question Find(int idQuestion)
        {
            try
            {
                return db.Questions.Find(idQuestion);
            }
            catch
            {
                return null;
            }
        }

        public List<Question> FindAll()
        {
            try
            {
                return db.Questions.ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<Question> FindAll2()
        {
            try
            {
                return db.Questions.Where(e => e.Status == true).ToList();
            }
            catch
            {
                return null;
            }
        }
        public Question Update(Question question)
        {
            try
            {
                var ques = db.Questions.Find(question.Id);
                ques.Question1 = question.Question1;
                ques.Status = question.Status;
                ques.Updated = DateTime.Now;
                db.SaveChanges();
                return ques;
            }
            catch
            {
                return null;
            }

        }
        public List<Question> FindByActive(bool n, int id)
        {
            try
            {
                return (from s in db.Questions
                        join q in db.QuestionSurveys on s.Id equals q.IdQuestion
                        join r in db.Surveys on q.IdSurvey equals r.Id
                        where r.Active == n && r.Status == true && r.Id == id
                        select new Question
                        {
                            Id = s.Id,
                            Question1 = s.Question1,
                            Updated = s.Updated,
                            Status = s.Status,
                            Answers = s.Answers

                        }).ToList();
            }
            catch
            {

                return null;
            }
        }
        public string CheckCorrect(int question, int ans)
        {
            try
            {
                return db.Questions.Find(question).Answers.SingleOrDefault(a => a.Id == ans).Status.ToString();
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public string CountQuestion(bool count, int id)
        {
            try
            {
                return (from s in db.Questions
                        join q in db.QuestionSurveys on s.Id equals q.IdQuestion
                        join r in db.Surveys on q.IdSurvey equals r.Id
                        where r.Active == count && r.Status == true && r.Id == id
                        select new Question
                        {
                            Question1 = s.Question1

                        }).Count().ToString();
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public List<QuestionDTO> findQuestion(int idSurvey)
        {
            try
            {

                return (from s in db.Questions
                        where !(from o in db.QuestionSurveys
                                where o.IdSurvey == idSurvey
                                select o.IdQuestion).Contains(s.Id) && s.Status == true
                        select s).Select(e => new QuestionDTO { Id = e.Id, Question1 = e.Question1 }).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
