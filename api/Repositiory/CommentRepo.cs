using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.interfaces;
using api.model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositiory
{
    public class CommentRepo(ApplicationDbContext context) : ICommentRepo
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}