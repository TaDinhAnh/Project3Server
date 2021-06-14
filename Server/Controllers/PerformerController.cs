using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/performer")]
    public class PerformerController : Controller
    {
        private IPerformerService performerService;
        public PerformerController(IPerformerService _performerService)
        {
            performerService = _performerService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(performerService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idPerformer}")]
        public IActionResult Find(int idPerformer)
        {
            try
            {
                return Ok(performerService.Find(idPerformer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Performer performer)
        {
            try
            {
                return Ok(performerService.Create(performer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Performer performer)
        {
            try
            {
                return Ok(performerService.Update(performer));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idPerformer}")]
        public IActionResult Del(int idPerformer)
        {
            try
            {
                return Ok(performerService.Del(idPerformer));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
