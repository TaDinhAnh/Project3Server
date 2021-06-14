using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Services;
namespace Server.Controllers
{
    [Route("api/topic")]
    public class TopicController : Controller
    {
        private ITopicService topicService;
        public TopicController(ITopicService _topicService)
        {
            topicService = _topicService;
        }

        [Produces("application/json")]
        [HttpGet("findAll")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(topicService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpGet("find/{idTop}")]
        public IActionResult Find(int idTop)
        {
            try
            {
                return Ok(topicService.Find(idTop));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Topic topic)
        {
            try
            {
                return Ok(topicService.Create(topic));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Topic topic)
        {
            try
            {
                return Ok(topicService.Update(topic));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("text/plain")]
        [Consumes("application/json")]
        [HttpDelete("Del/{idTopic}")]
        public IActionResult Del(int idTopic)
        {
            try
            {
                return Ok(topicService.Del(idTopic));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
