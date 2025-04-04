using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Comment;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Mappers;

namespace demo_dotnetcore_web_api.src.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        public CommentService(ICommentRepository repository)
        {
            this._commentRepo = repository;
        }

        public async Task<List<CommentDto>> GetAllAsync()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDtos = comments.Select(c => c.ToCommentDto()).ToList();
            return commentDtos;
        }

        public async Task<CommentDto?> GetByIdAsync(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null)
            {
                return null;
            }
            return comment.ToCommentDto();
        }
    }
}