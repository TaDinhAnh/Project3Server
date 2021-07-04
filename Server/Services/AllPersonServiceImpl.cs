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

        public string Del(string idAllPerson)
        {
            try
            {
                db.AllPeople.Where(e => e.IdPerson == idAllPerson).SingleOrDefault().Status = false;
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public AllPerson Find(string idAllperson)
        {

            return db.AllPeople.Where(e => e.IdPerson == idAllperson).Select(e => new AllPerson
            {
                IdPerson = idAllperson,
                Class = e.Class,
                Dob = e.Dob,
                Gender = e.Gender,
                Img = e.Img,
                Name = e.Name,
                Position = e.Position,
                Status = e.Status
            }).SingleOrDefault();

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

        public List<AllPerson> FindStaff()
        {
            try
            {
                return db.AllPeople.Where(e => e.Position == "gv" || e.Position == "nv" && e.Status == true).ToList();
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
                var person = db.AllPeople.Where(e => e.IdPerson == allPerson.IdPerson).FirstOrDefault();
                person.Name = allPerson.Name;
                person.Position = allPerson.Position;
                person.Class = allPerson.Class;
                person.Dob = allPerson.Dob;
                person.Gender = allPerson.Gender;
                person.Status = allPerson.Status;
                if (allPerson.Img != null) person.Img = allPerson.Img;
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
