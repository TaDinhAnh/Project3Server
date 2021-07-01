using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class TopicServiceImpl : ITopicService
    {
        private readonly DatabaseContext db;
        public TopicServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Topic topic)
        {
            try
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idTopic)
        {
            try
            {
                db.Topics.Remove(db.Topics.Find(idTopic));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Topic Find(int idTopic)
        {
            try
            {
                return db.Topics.Find(idTopic);
            }
            catch
            {
                return null;
            }
        }

        public List<Topic> FindAll()
        {
            try
            {
                return db.Topics.Where(e => e.Status == true).ToList();
            }
            catch
            {
                return null;
            }
        }

        public string Update(Topic topic)
        {
            try
            {

                db.Entry(topic).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
