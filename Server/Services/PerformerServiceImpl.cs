using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class PerformerServiceImpl : IPerformerService
    {
        private readonly DatabaseContext db;
        public PerformerServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Performer performer)
        {
            try
            {
                db.Performers.Add(performer);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idPerformer)
        {
            try
            {
                db.Performers.Find(idPerformer).Status = false;
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Performer Find(int idPerformer)
        {
            try
            {
                return db.Performers.Find(idPerformer);
            }
            catch
            {
                return null;
            }
        }

        public List<Performer> FindAll()
        {
            try
            {
                return db.Performers.Where(e => e.Status == true).ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<Performer> FindAll2()
        {
            try
            {
                return db.Performers.ToList();
            }
            catch
            {
                return null;
            }
        }
        public string Update(Performer performer)
        {
            try
            {
                var per = db.Performers.Find(performer.Id);
                per.Name = performer.Name;
                per.Status = performer.Status;
                per.Dob = performer.Dob;
                per.Gender = performer.Gender;
                if (performer.Img != null) per.Img = performer.Img;
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public List<Performer> Find2(int idSeminar)
        {
            try
            {

                return (from s in db.Performers
                        where !(from o in db.PerformenSeminars
                                where o.IdSeminar == idSeminar
                                select o.IdPerforment).Contains(s.Id)
                        select s).ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}
