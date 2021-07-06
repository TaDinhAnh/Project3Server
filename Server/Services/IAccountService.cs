using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.DTO;
namespace Server.Services
{
    public interface IAccountService
    {
        List<Account> FindAll();
        Account Find(int idAcc);
        List<Account> Del(int idAcc);
        int CountActive();
        List<Account> FindAccAcitve();
        string Accept(int idAccount);
        string DelAccept(int idAccount);
        int CountAcc(string idPeople);

        string Create(Account acc);
        Account Login(Account account);
        string Update(Account acc);
        string UpdatePass(Account acc);
        string CheckMail(string mail);
        Account FindMail(string mail);
        List<AccountDTO> FindTop(int number);
    }
}
