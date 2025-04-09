using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.src.Dtos.Comment;
using demo_dotnetcore_web_api.src.Extensions;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Mappers;
using demo_dotnetcore_web_api.src.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace demo_dotnetcore_web_api.src.Controllers
{

    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService service, UserManager<AppUser> userManager)
        {
            this._commentService = service;
            this._userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            var commentDtos = await _commentService.GetAllAsync();
            return Ok(commentDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentDto = await _commentService.GetByIdAsync(id);
            if (commentDto == null)
            {
                return NotFound();
            }
            return Ok(commentDto);
        }


        [HttpPost("{symbol:alpha}")]
        public async Task<IActionResult> Create([FromRoute] string symbol, CreateCommentDto createCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);

            var commentDto = await _commentService.CreateAsync(symbol, createCommentDto, appUser!);
            if (commentDto == null)
            {
                return BadRequest("Stock does not exist");
            }

            return CreatedAtAction(nameof(Create), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentDto = await _commentService.UpdateAsync(id, updateDto);
            if (commentDto == null)
            {
                return NotFound("Comment not found");
            }

            return Ok(commentDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentDto = await _commentService.DeleteAsync(id);
            if (commentDto == null)
            {
                return NotFound("Comment does not found!");
            }

            return NoContent();
        }
    }
}