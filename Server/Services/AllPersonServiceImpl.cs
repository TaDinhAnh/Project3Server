using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class AllPersonServiceImpl : IAllPersonService
    {
        private readonly DatabaseContext db;
        public AllPersonServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(AllPerson allPerson)
        {
            try
            {
                db.AllPeople.Add(allPerson);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idAllPerson)
        {
            try
            {
                db.AllPeople.Remove(db.AllPeople.Find(idAllPerson));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public AllPerson Find(int idAllperson)
        {
            try
            {
                return db.AllPeople.Find(idAllperson);
            }
            catch
            {
                return null;
            }
        }


        public List<AllPerson> FindAll()
        {
            try
            {
                return db.AllPeople.ToList();
            }
            catch
            {
                return null;
            }
        }

        public string Update(AllPerson allPerson)
        {
            try
            {
                db.Entry(allPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
