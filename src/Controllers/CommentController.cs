using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace demo_dotnetcore_web_api.src.Controllers
{

    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService service)
        {
            this._commentService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commentDtos = await _commentService.GetAllAsync();
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commentDto = await _commentService.GetByIdAsync(id);
            if (commentDto == null)
            {
                return NotFound();
            }
            return Ok(commentDto);
        }

    }
}