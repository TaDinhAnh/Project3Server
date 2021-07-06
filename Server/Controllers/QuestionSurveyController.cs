using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/questionsurvey")]
    public class QuestionSurveyController : Controller
    {
        private IQuestionSurveyService questionsurveyService;
        public QuestionSurveyController(IQuestionSurveyService _questionsurveyService)
        {
            questionsurveyService = _questionsurveyService;
        }

        [Produces("application/json")]
        [HttpGet("checkquestion/{idsurvey}")]
        public IActionResult Checkquestion(int idsurvey)
        {
            try
            {
                return Ok(questionsurveyService.Checkquestion(idsurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] QuestionSurvey questionSurvey)
        {
            try
            {
                return Ok(questionsurveyService.Create(questionSurvey));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
