using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface ICommentService
    {
        List<Comment> FindAll();
        string Create(Comment comment);
        List<CommentDTO> FindAll2();
    }
}
