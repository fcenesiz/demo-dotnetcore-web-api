using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_dotnetcore_web_api.Models;
using demo_dotnetcore_web_api.src.Dtos.Comment;

namespace demo_dotnetcore_web_api.src.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commenModel)
        {
            return new CommentDto
            {
                Id = commenModel.Id,
                Title = commenModel.Title,
                Content = commenModel.Content,
                CreatedOn = commenModel.CreatedOn,
                StockId = commenModel.StockId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }


    }
}