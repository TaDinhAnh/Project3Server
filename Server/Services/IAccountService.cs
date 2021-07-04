using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IAccountService
    {
        Account Login(Account account);
        List<Account> FindAll();
        Account Find(int idAcc);
        string Create(Account acc);
        List<Account> Del(int idAcc);
        string Update(Account acc);
        int CountActive();
        List<Account> FindAccAcitve();
        string Accept(int idAccount);
        string DelAccept(int idAccount);
        int CountAcc(string idPeople);
    }
}
