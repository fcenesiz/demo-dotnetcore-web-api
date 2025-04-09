using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Comment;
using demo_dotnetcore_web_api.src.Helpers;
using demo_dotnetcore_web_api.src.Interfaces;
using demo_dotnetcore_web_api.src.Interfaces.Service;
using demo_dotnetcore_web_api.src.Mappers;
using demo_dotnetcore_web_api.src.Models;
using Microsoft.AspNetCore.Identity;

namespace demo_dotnetcore_web_api.src.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockService _stockService;
        private readonly IFMPService _fMPService;


        public CommentService(ICommentRepository repository, IStockService stockService, IFMPService fMPService, UserManager<AppUser> userManager)
        {
            this._commentRepo = repository;
            this._stockService = stockService;
            this._fMPService = fMPService;
        }

        public async Task<CommentDto?> CreateAsync(string symbol, CreateCommentDto createCommentDto, AppUser appUser)
        {
            var stock = await _stockService.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                stock = await _fMPService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return null;
                }
                await _stockService.CreateAsync(stock);
            }



            var commentModel = createCommentDto.ToCommentFromCreate(stock.Id);
            commentModel.AppUserId = appUser.Id;
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

        public async Task<List<CommentDto>> GetAllAsync(CommentQueryObject queryObject)
        {
            var comments = await _commentRepo.GetAllAsync(queryObject);
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