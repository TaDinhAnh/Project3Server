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
    }
}
