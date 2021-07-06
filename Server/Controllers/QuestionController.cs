using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/question")]
    public class QuestionController : Controller
    {
        private IQuestionService questionService;
        public QuestionController(IQuestionService _questionService)
        {
            questionService = _questionService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(questionService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAll2")]
        public IActionResult FindAll2()
        {
            try
            {
                return Ok(questionService.FindAll2());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findQuestion/{idSurvey}")]
        public IActionResult findQuestion(int idSurvey)
        {
            try
            {
                return Ok(questionService.findQuestion(idSurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idQuestion}")]
        public IActionResult Find(int idQuestion)
        {
            try
            {
                return Ok(questionService.Find(idQuestion));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Question question)
        {
            try
            {
                return Ok(questionService.Create(question));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Question question)
        {
            try
            {
                return Ok(questionService.Update(question));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpDelete("Del/{idQuestionic}")]
        public IActionResult Del(int idQuestionic)
        {
            try
            {
                return Ok(questionService.Del(idQuestionic));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("checkcorrect/{idques}/{idans}")]
        public IActionResult CheckCorrect(int idques, int idans)
        {
            try
            {
                return Ok(questionService.CheckCorrect(idques, idans));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("count/{n}/{id}")]
        public IActionResult CountQuestion(bool n, int id)
        {
            try
            {
                return Ok(questionService.CountQuestion(n, id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findbyactive/{n}/{id}")]
        public IActionResult FindByActive(bool n, int id)
        {
            try
            {
                return Ok(questionService.FindByActive(n, id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
