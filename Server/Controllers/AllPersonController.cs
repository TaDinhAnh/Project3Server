using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Server.Models;
namespace Server.Controllers
{
    [Route("api/allperson")]
    public class AllPersonController : Controller
    {
        private IAllPersonService allPersonService;
        public AllPersonController(IAllPersonService _allPersonService)
        {
            allPersonService = _allPersonService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(allPersonService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findStaff")]
        public IActionResult FindStaff()
        {
            try
            {
                return Ok(allPersonService.FindStaff());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idAllPerson}")]
        public IActionResult Find(string idAllPerson)
        {
            try
            {
                return Ok(allPersonService.Find(idAllPerson));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] AllPerson allPerson)
        {
            try
            {
                return Ok(allPersonService.Create(allPerson));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] AllPerson allPerson)
        {
            try
            {
                return Ok(allPersonService.Update(allPerson));
            }
            catch
            {
                return BadRequest();
            }
        }
      
      
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idAllPerson}")]
        public IActionResult Del(int idAllPerson)
        {
            try
            {
                return Ok(allPersonService.Del(idAllPerson));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
