using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
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

        public List<SeminarDTO> Del(int idSeminar)
        {
            try
            {
                db.Seminars.Find(idSeminar).Status = false;
                db.SaveChanges();
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        select
                        new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Seminar DelPerforment(int idSeminar, int idPerforment)
        {
            try
            {
                var temp = db.PerformenSeminars.SingleOrDefault(e => e.IdPerforment == idPerforment && e.IdSeminar == idSeminar);
                db.PerformenSeminars.Remove(temp);
                db.SaveChanges();
                return db.Seminars.Find(idSeminar);
            }
            catch
            {
                return null;
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
        public List<SeminarDTO> FindAll2()
        {
            try
            {
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        where s.Active == true
                        select
                        new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public SeminarDTO FindDTO(int idSeminar)
        {
            try
            {
                return (SeminarDTO)from s in db.Seminars
                                   join p in db.AllPeople on s.Presenters equals p.IdPerson
                                   where s.Id == idSeminar
                                   select new SeminarDTO { Id = s.Id, Name = s.Name, Img = s.Img, Presenters = s.Presenters, NamePresenters = p.Name, TimeStart = s.TimeStart.ToString(), TimeEnd = s.TimeEnd.ToString(), Day = s.Day, Place = s.Place, Maximum = s.Maximum, Descriptoin = s.Descriptoin, Status = s.Status };

            }
            catch
            {
                return null;
            }
        }

        public List<SeminarDTO> RecentSeminar(int n)
        {
            try
            {
                return (from s in db.Seminars
                        join p in db.AllPeople on s.Presenters equals p.IdPerson
                        where s.Day < DateTime.Now && s.Status == true
                        orderby s.Day descending
                        select
                        new SeminarDTO { Name = s.Name, Img = s.Img, NamePresenters = p.Name, Day = s.Day, Status = s.Status }).Take(n).ToList();

            }
            catch
            {
                return null;
            }
        }

        public string Update(SeminarDTO seminarDTO)
        {
            try
            {
                var seminar = db.Seminars.Find(seminarDTO.Id);
                if (seminarDTO.Img != null) seminar.Img = seminarDTO.Img;
                seminar.Name = seminarDTO.Name;
                seminar.TimeStart = TimeSpan.Parse(seminarDTO.TimeStart);
                seminar.TimeEnd = TimeSpan.Parse(seminarDTO.TimeEnd);
                seminar.Day = seminarDTO.Day;
                seminar.Place = seminarDTO.Place;
                seminar.Maximum = seminarDTO.Maximum;
                seminar.Descriptoin = seminarDTO.Descriptoin;
                seminar.Status = seminarDTO.Status;

                db.SaveChanges();
                return seminar.Id.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public Seminar UpdatePre(int idSeminar, string idPrecenter)
        {
            try
            {
                var seminar = db.Seminars.Find(idSeminar);
                seminar.Presenters = idPrecenter;
                db.SaveChanges();
                return seminar;
            }
            catch
            {
                return null;
            }
        }
        public Seminar AddPerforment(PerformenSeminar performenSeminar)
        {
            try
            {
                var seminar = db.Seminars.Find(performenSeminar.IdSeminar);
                var performent = db.Performers.Find(performenSeminar.IdPerforment);
                performent.PerformenSeminars.Add(performenSeminar);
                seminar.PerformenSeminars.Add(performenSeminar);
                db.SaveChanges();
                return db.Seminars.Find(performenSeminar.IdSeminar);
            }
            catch
            {
                return null;
            }
        }

        public int CountAccept()
        {
            try
            {
                return db.Seminars.Where(e => e.Active == false).Count();
            }
            catch
            {
                return 0;
            }
        }
        public List<Seminar> ListAccept()
        {
            try
            {
                return db.Seminars.Where(e => e.Active == false).ToList();
            }
            catch
            {
                return null;
            }
        }
        public string Accept(int idSeminar)
        {
            try
            {
                db.Seminars.Find(idSeminar).Active = true;
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DelAccept(int idSeminar)
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
    }
}
