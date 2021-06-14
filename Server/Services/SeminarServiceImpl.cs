using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class SeminarServiceImpl : ISeminarService
    {
        private readonly DatabaseContext db;
        public SeminarServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Seminar seminar)
        {
            try
            {
                db.Seminars.Add(seminar);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idSeminar)
        {
            try
            {
                db.Seminars.Remove(db.Seminars.Find(idSeminar));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Seminar Find(int idSeminar)
        {
            try
            {
                return db.Seminars.Find(idSeminar);
            }
            catch
            {
                return null;
            }
        }

        public List<Seminar> FindAll()
        {
            try
            {
                return db.Seminars.ToList();
            }
            catch
            {
                return null;
            }
        }

        public string Update(Seminar seminar)
        {
            try
            {

                db.Entry(seminar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
