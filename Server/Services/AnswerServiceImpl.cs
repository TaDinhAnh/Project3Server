using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class AnswerServiceImpl : IAnswerService
    {
        private readonly DatabaseContext db;
        public AnswerServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public List<Answer> Create(Answer answer)
        {
            try
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return db.Answers.Where(e => e.IdQuestion == answer.IdQuestion).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Answer> Del(int idAnswer, int idQues)
        {
            try
            {
                var answer = db.Answers.Where(e => e.Id == idAnswer && e.IdQuestion == idQues).SingleOrDefault();
                db.Answers.Remove(answer);
                db.SaveChanges();
                return db.Questions.Find(idQues).Answers.Select(e => new Answer { Id = e.Id, IdQuestion = e.IdQuestion, Answer1 = e.Answer1, Updated = e.Updated, Status = e.Status }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Answer Find(int idAnswer)
        {
            try
            {
                return db.Answers.Find(idAnswer);
            }
            catch
            {
                return null;
            }
        }

        public List<Answer> FindAll()
        {
            try
            {
                return db.Answers.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Answer> Update(Answer answer)
        {
            try
            {

                db.Entry(answer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return db.Answers.Where(e => e.IdQuestion == answer.IdQuestion).Select(e => new Answer { Id = e.Id, IdQuestion = e.IdQuestion, Answer1 = e.Answer1, Updated = e.Updated, Status = e.Status }).ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}

