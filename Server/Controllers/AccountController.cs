using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        private IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(accountService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idAcc}")]
        public IActionResult Find(int idAcc)
        {
            try
            {
                return Ok(accountService.Find(idAcc));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Account account)
        {
            try
            {
                return Ok(accountService.Create(account));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account account)
        {
            try
            {


                return Ok(accountService.Login(account));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Account account)
        {
            try
            {
                return Ok(accountService.Update(account));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idAcc}")]
        public IActionResult Del(int idAcc)
        {
            try
            {
                return Ok(accountService.Del(idAcc));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("countActive")]
        public IActionResult CountActive()
        {
            try
            {
                return Ok(accountService.CountActive() + " ");
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("findAccActive")]
        public IActionResult FindAccActive()
        {
            try
            {
                return Ok(accountService.FindAccAcitve());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("accept/{idAcc}")]
        public IActionResult Accept(int idAcc)
        {
            try
            {
                return Ok(accountService.Accept(idAcc));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpDelete("delAccept/{idAcc}")]
        public IActionResult DelAccept(int idAcc)
        {
            try
            {
                return Ok(accountService.DelAccept(idAcc));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [HttpGet("countAcc/{idPeople}")]
        public IActionResult CountAcc(string idPeople)
        {
            try
            {
                return Ok(accountService.CountAcc(idPeople)+" ");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
