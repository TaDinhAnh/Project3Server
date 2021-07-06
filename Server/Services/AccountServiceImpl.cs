using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DTO;
using System.Diagnostics;

namespace Server.Services
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly DatabaseContext db;
        public AccountServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }

        public int CountActive()
        {
            try
            {
                return db.Accounts.Where(e => e.Active == false).Count();
            }
            catch 
            {
                return 0;
            }
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
                return db.Accounts.Select(e => new Account { Id = e.Id, IdPeople = e.IdPeople, UserName = e.UserName, Img = e.Img, Role = e.Role, Date = e.Date, Status = e.Status }).ToList();
            }
            catch
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

        public List<Account> FindAccAcitve()
        {
            try
            {
                return db.Accounts.Where(e => e.Active == false).Select(e => new Account { Id = e.Id, IdPeople = e.IdPeople, UserName = e.UserName, Img = e.Img, Role = e.Role, Date = e.Date, Status = e.Status }).ToList();
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
                return db.Accounts.Where(e => e.Active == true).ToList();
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
                var acc = db.Accounts.SingleOrDefault(u => u.UserName == account.UserName && u.Active == true && u.Status == true);
                if (acc != null)
                {
                    if (BCrypt.Net.BCrypt.Verify(account.Password, acc.Password))
                    {
                        return acc;
                    }
                }
                return null;
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
        public string Accept(int idAccount)
        {
            try
            {
                var acc = db.Accounts.Find(idAccount);
                acc.Active = true;
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string DelAccept(int idAccount)
        {
            try
            {
                var acc = db.Accounts.Find(idAccount);
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public int CountAcc(string idPeople)
        {
            try
            {

                return db.Accounts.Where(e => e.IdPeople == idPeople && e.Active == true).Count();
            }
            catch
            {
                return 0;
            }
        }
        public Account FindMail(string mail)
        {
            try
            {
                return db.Accounts.FirstOrDefault(a => a.Email == mail);
            }
            catch
            {

                return null;
            }
        }

        public List<AccountDTO> FindTop(int number)
        {
            try
            {
                return (from a in db.Accounts
                        join s in db.Scores on a.Id equals s.IdAcc
                        select new AccountDTO
                        {
                            Id = a.Id,
                            UserName = a.UserName,
                            Img = a.Img,
                            Class = a.Class,
                            Score = s.Score1
                        }).Take(number).OrderByDescending(e => e.Score).ToList();
            }
            catch
            {
                return null;
            }
        }

        public string UpdatePass(Account acc)
        {
            try
            {
                var acc2 = db.Accounts.FirstOrDefault(s => s.Email == acc.Email);
                acc2.Password = acc.Password;
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string CheckMail(string mail)
        {
            try
            {
                return db.Accounts.Count(a => a.Email == mail).ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
