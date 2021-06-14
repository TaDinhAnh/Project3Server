using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Server.Models;
namespace Server.Controllers
{
    [Route("api/answer")]
    public class AnswerController : Controller
    {
        private IAnswerService answerService;
        public AnswerController(IAnswerService _answerService)
        {
            answerService = _answerService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(answerService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idAnswer}")]
        public IActionResult Find(int idAnswer)
        {
            try
            {
                return Ok(answerService.Find(idAnswer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Answer answer)
        {
            try
            {
                return Ok(answerService.Create(answer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Answer answer)
        {
            try
            {
                return Ok(answerService.Update(answer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idAnswer}")]
        public IActionResult Del(int idAnswer)
        {
            try
            {
                return Ok(answerService.Del(idAnswer));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
