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
        public string Create(Question question)
        {
            try
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idQuestion)
        {
            try
            {
                db.Questions.Remove(db.Questions.Find(idQuestion));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
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

        public string Update(Question question)
        {
            try
            {

                db.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
