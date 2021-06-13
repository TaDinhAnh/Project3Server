using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
   public interface IAccountService
    {
        List<Account> FindAll();
        Account Find(int idAcc);
        string Create(Account acc);
        string Del(int idAcc);
        string Update(Account acc);
    }
}
