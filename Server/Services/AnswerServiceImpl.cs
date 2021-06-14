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
        public string Create(Answer answer)
        {
            try
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idAnswer)
        {
            try
            {
                db.Answers.Remove(db.Answers.Find(idAnswer));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
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

        public string Update(Answer answer)
        {
            try
            {

                db.Entry(answer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

