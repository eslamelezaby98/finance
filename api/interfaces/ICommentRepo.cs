using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.model;

namespace api.interfaces
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAll();
    }
}