using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ScoreServiceImpl : IScoreService
    {
        private readonly DatabaseContext db;
        public ScoreServiceImpl(DatabaseContext databaseContext)
        {
            db = databaseContext;
        }
        public List<Score> Top(int n)
        {
            try
            {
                return db.Scores.OrderByDescending(e => e.IdSurvey).Take(n).ToList();
            }
            catch
            {
                return null;
            }
        }
        public string CheckExists(int idAcc, int idSurvey)
        {
            try
            {
                return db.Scores.Count(s => s.IdAcc == idAcc && s.IdSurvey == idSurvey).ToString();
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public string Create(Score score)
        {
            try
            {
                db.Scores.Add(score);
                db.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
