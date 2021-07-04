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
    }
}
