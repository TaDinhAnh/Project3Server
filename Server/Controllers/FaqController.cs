using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/faq")]
    public class FaqController : Controller
    {
        private IFaqService faqService;
        public FaqController(IFaqService _faqService)
        {
            faqService = _faqService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(faqService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idFaq}")]
        public IActionResult Find(int idFaq)
        {
            try
            {
                return Ok(faqService.Find(idFaq));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Faq faq)
        {
            try
            {
                return Ok(faqService.Create(faq));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Faq faq)
        {
            try
            {
                return Ok(faqService.Update(faq));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idFaq}")]
        public IActionResult Del(int idFaq)
        {
            try
            {
                return Ok(faqService.Del(idFaq));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
