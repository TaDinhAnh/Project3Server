using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
using Server.DTO;
namespace Server.Controllers
{
    [Route("api/survey")]
    public class SurveyController : Controller
    {
        private ISurveyService surveyService;
        public SurveyController(ISurveyService _surveyService)
        {
            surveyService = _surveyService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(surveyService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idSurvey}")]
        public IActionResult Find(int idSurvey)
        {
            try
            {
                return Ok(surveyService.Find(idSurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] SurveyDTO survey)
        {
            try
            {
                return Ok(surveyService.Create(survey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Survey survey)
        {
            try
            {
                return Ok(surveyService.Update(survey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpDelete("Del/{idSurvey}")]
        public IActionResult Del(int idSurvey)
        {
            try
            {
                return Ok(surveyService.Del(idSurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findtop/{active}")]
        public IActionResult FindTop(bool active)
        {
            try
            {
                return Ok(surveyService.FindTop(active));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addQes")]
        public IActionResult AddQues([FromBody] QuestionSurvey questionSurvey)
        {
            try
            {
                return Ok(surveyService.AddQues(questionSurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpDelete("delQues/{idQues}/{idSurvey}")]
        public IActionResult DelQues(int idQues, int idSurvey)
        {
            try
            {
                return Ok(surveyService.DelQues(new QuestionSurvey { IdQuestion = idQues, IdSurvey = idSurvey }));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
