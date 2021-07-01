using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/img")]
    public class ImgController : Controller
    {
        private IImgService imgService;
        public ImgController(IImgService _imgService)
        {
            imgService = _imgService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(imgService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idImg}")]
        public IActionResult Find(int idImg)
        {
            try
            {
                return Ok(imgService.Find(idImg));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Img img)
        {
            try
            {
                return Ok(imgService.Create(img));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Img img)
        {
            try
            {
                return Ok(imgService.Update(img));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idImg}")]
        public IActionResult Del(int idImg)
        {
            try
            {
                return Ok(imgService.Del(idImg));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]

        [HttpGet("getImgSer/{idSeminar}")]
        public IActionResult GetImgSer(int idSeminar)
        {
            try
            {
                return Ok(imgService.GetImgSer(idSeminar));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]

        [HttpDelete("delImgSer/{idSeminar}/{idImg}")]
        public IActionResult DelImgSer(int idSeminar, int idImg)
        {
            try
            {
                return Ok(imgService.DelImgSer(idSeminar, idImg));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
