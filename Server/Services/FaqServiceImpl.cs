using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class FaqServiceImpl : IFaqService
    {
        private readonly DatabaseContext db;
        public FaqServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public List<Faq> Create(Faq faq)
        {
            try
            {
                db.Faqs.Add(faq);

                db.SaveChanges();
                return db.Faqs.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Faq> Del(int idFaq)
        {
            try
            {
                db.Faqs.Remove(db.Faqs.Find(idFaq));
                db.SaveChanges();
                return db.Faqs.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Faq Find(int idFaq)
        {
            try
            {
                return db.Faqs.Find(idFaq);
            }
            catch
            {
                return null;
            }
        }

        public List<Faq> FindAll()
        {
            try
            {
                return db.Faqs.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Faq> Update(Faq faq)
        {
            try
            {
                db.Entry(faq).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return db.Faqs.ToList(); ;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
