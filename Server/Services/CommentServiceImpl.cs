using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public class CommentServiceImpl : ICommentService
    {
        private readonly DatabaseContext db;
        public CommentServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Comment> FindAll()
        {
            try
            {
                return db.Comments.ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<CommentDTO> FindAll2()
        {
            try
            {
                return (from c in db.Comments
                        join a in db.Accounts on c.IdAcc equals a.Id
                        orderby c.Id descending
                        select new CommentDTO
                        {
                            Id = c.Id,
                            IdAcc = c.IdAcc,
                            UserName = a.UserName,
                            Massage = c.Massage,
                            Email = a.Email,
                            Img = a.Img
                        }
                    ).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}

