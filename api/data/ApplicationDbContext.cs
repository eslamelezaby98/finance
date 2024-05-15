using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.model;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}