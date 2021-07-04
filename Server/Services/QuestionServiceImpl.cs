using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
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
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
