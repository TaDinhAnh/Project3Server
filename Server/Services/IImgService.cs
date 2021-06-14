using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IImgService
    {
        List<Img> FindAll();
        Img Find(int idImg);
        string Create(Img img);
        string Del(int idImg);
        string Update(Img img);
    }
}
