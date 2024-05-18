using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.comment;
using api.interfaces;
using api.model;
using Microsoft.EntityFrameworkCore;

namespace api.Repositiory
{
    public class CommentRepo(ApplicationDbContext context) : ICommentRepo
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Comment> Create(Comment comment)
        {

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }


        public async Task<Comment?> GetById(int id)
        {
            Comment? comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            else
            {
                return comment;
            }
        }

        public async Task<bool> IsCommentExits(int id)
        {
            return await _context.Comments.AnyAsync(e => e.Id == id);
        }

        public async Task<Comment?> Update(int id, UpdateCommentDto updateCommentDto)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(e => e.Id == id);
            if (comment == null)
            {
                return null;
            }
            else
            {
                comment.Title = updateCommentDto.Title;
                comment.Content = updateCommentDto.Content;
                await _context.SaveChangesAsync();
                return comment;
            }
        }
    }
}