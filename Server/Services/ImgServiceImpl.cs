using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public class ImgServiceImpl : IImgService
    {
        private readonly DatabaseContext db;
        public ImgServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Img img)
        {
            try
            {
                db.Imgs.Add(img);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idImg)
        {
            try
            {
                db.Imgs.Remove(db.Imgs.Find(idImg));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Img Find(int idImg)
        {
            try
            {
                return db.Imgs.Find(idImg);
            }
            catch
            {
                return null;
            }
        }

        public List<Img> FindAll()
        {
            try
            {
                return db.Imgs.ToList();
            }
            catch
            {
                return null;
            }
        }

        public string Update(Img img)
        {
            try
            {

                db.Entry(img).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

