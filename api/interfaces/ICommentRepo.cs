using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto.comment;
using api.model;

namespace api.interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAll();

        Task<Comment?> GetById(int id);

        Task<Comment> Create(Comment comment);
        Task<Comment?> Update(int id, UpdateCommentDto updateCommentDto);

        Task<bool> IsCommentExits(int id);

    }
}