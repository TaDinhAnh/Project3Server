using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/seminar")]
    public class SeminarController : Controller
    {
        private ISeminarService seminarService;
        public SeminarController(ISeminarService _seminarService)
        {
            seminarService = _seminarService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(seminarService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findRecent")]
        public IActionResult findRecent()
        {
            try
            {
                return Ok(seminarService.RecentSeminar(4));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idSeminar}")]
        public IActionResult Find(int idSeminar)
        {
            try
            {
                return Ok(seminarService.Find(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Seminar seminar)
        {
            try
            {
                return Ok(seminarService.Create(seminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Seminar seminar)
        {
            try
            {
                return Ok(seminarService.Update(seminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idSeminar}")]
        public IActionResult Del(int idSeminar)
        {
            try
            {
                return Ok(seminarService.Del(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
