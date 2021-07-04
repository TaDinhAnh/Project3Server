using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IAllPersonService
    {
        List<AllPerson> FindAll();
        AllPerson Find(string idAllPerson);
        string Create(AllPerson allPerson);
        string Del(string idAllPerson);
        string Update(AllPerson allPerson);
        List<AllPerson> FindStaff();
    }
}
