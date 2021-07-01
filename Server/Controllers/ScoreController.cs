using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Server.Models;
namespace Server.Controllers
{
    [Route("api/score")]
    public class ScoreController : Controller
    {
        private IScoreService scoreService;
        public ScoreController(IScoreService _scoreService)
        {
            scoreService = _scoreService;
        }
        [Route("top/{n}")]
        public IActionResult Top(int n)
        {
            try
            {
                return Ok(scoreService.Top(n));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
