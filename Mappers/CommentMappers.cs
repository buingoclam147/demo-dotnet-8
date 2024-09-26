using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment stockModel)
        {
            return new CommentDto
            {
                Id = stockModel.Id,
                StockId = stockModel.StockId,
                Title = stockModel.Title,
                Content = stockModel.Content,
                CreatedAt = stockModel.CreatedAt
            };
        }
    }
}