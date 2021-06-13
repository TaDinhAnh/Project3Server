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
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public string Del(int idAcc)
        {
            try
            {
                db.Accounts.Remove(db.Accounts.Find(idAcc));
                db.SaveChanges();
                return "Seccuss";
            }
            catch (Exception e)
            {
                return e.Message;
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

        public string Update(Account acc)
        {
            try
            {
                var accCurrent = db.Accounts.Find(acc.Id);
                accCurrent.Id = acc.Id;
                accCurrent.IdPeople = acc.IdPeople;
                accCurrent.UserName = acc.UserName;
                accCurrent.Password = acc.Password;
                accCurrent.Role = acc.Role;
                accCurrent.Status = acc.Status;
                accCurrent.Class = acc.Class;
                accCurrent.Date = acc.Date;
                db.Entry(accCurrent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return "success";
            }
            catch(Exception e)
            {
                return e.Message;
            }
           
        }
    }
}
