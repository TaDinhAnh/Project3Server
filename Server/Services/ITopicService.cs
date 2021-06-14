using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface ITopicService
    {
        List<Topic> FindAll();
        Topic Find(int idTopic);
        string Create(Topic topic);
        string Del(int idTopic);
        string Update(Topic topic);
    }
}
