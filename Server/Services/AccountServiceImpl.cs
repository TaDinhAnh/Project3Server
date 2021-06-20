using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly DatabaseContext db;
        public AccountServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public string Create(Account acc)
        {
            try
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Account> Del(int idAcc)
        {
            try
            {
                var acc = db.Accounts.Find(idAcc);
                acc.Status = false;
                db.SaveChanges();
                return db.Accounts.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Account Find(int idAcc)
        {
            try
            {
                return db.Accounts.Find(idAcc);
            }
            catch
            {
                return null;
            }
        }

        public List<Account> FindAll()
        {
            try
            {
                return db.Accounts.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Account Login(Account account)
        {
            try
            {
                return db.Accounts.FirstOrDefault(e => e.UserName == account.UserName && e.Password == account.Password && e.Status == true);
            }
            catch
            {
                return null;
            }
        }

        public string Update(Account acc)
        {
            try
            {

                db.Entry(acc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
