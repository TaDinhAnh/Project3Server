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
        [Produces("text/plain")]
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
    }
}
