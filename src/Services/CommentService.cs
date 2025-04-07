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
        private readonly IStockService _stockService;

        public CommentService(ICommentRepository repository, IStockService stockService)
        {
            this._commentRepo = repository;
            this._stockService = stockService;
        }

        public async Task<CommentDto?> CreateAsync(int stockId, CreateCommentDto createCommentDto)
        {
            if (!await _stockService.StockExistsAsync(stockId))
            {
                return null;
            }
            var commentModel = createCommentDto.ToCommentFromCreate(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return commentModel.ToCommentDto();
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commenModel = await _commentRepo.DeleteAsync(id);
            if (commenModel == null)
            {
                return null;
            }

            return commenModel;
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

        public async Task<CommentDto?> UpdateAsync(int id, UpdateCommentRequestDto updateCommentRequestDto)
        {
            var commentModel = await _commentRepo.UpdateAsync(id, updateCommentRequestDto.ToCommentFromUpdate());
            if (commentModel == null)
            {
                return null;
            }

            return commentModel.ToCommentDto();
        }
    }
}