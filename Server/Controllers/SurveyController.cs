using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
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
        public IActionResult Create([FromBody] Survey survey)
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
        [Consumes("application/json")]
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
    }
}
