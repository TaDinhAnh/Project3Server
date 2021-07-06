using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/comment")]
    public class CommentController : Controller
    {
        private ICommentService commentService;
        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(commentService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [HttpGet("findAll2")]
        public IActionResult FindAll2()
        {
            try
            {
                return Ok(commentService.FindAll2());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Comment comment)
        {
            try
            {
                return Ok(commentService.Create(comment));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
