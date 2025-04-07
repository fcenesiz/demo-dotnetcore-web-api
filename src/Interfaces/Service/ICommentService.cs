using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Comment;

namespace demo_dotnetcore_web_api.src.Interfaces
{
    public interface ICommentService
    {
        public Task<List<CommentDto>> GetAllAsync();
        public Task<CommentDto?> GetByIdAsync(int id);
        public Task<CommentDto?> CreateAsync(int stockId, CreateCommentDto createCommentDto);

        public Task<CommentDto?> UpdateAsync(int id, UpdateCommentRequestDto updateCommentRequestDto);
        public Task<Comment?> DeleteAsync(int id);
    }
}