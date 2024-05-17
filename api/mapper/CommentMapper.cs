using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto.comment;
using api.model;

namespace api.mapper
{
    public static class CommentMapper
    {
        public static CommentsDto ToCommentDto(this Comment commentModel)
        {
            return new CommentsDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto createComment, int stockId)
        {
            return new Comment
            {
                Title = createComment.Title,
                Content = createComment.Content,
                StockId = stockId,
            };
        }


    }
}