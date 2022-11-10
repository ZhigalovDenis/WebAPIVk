using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using WebAPIVk.Models;

namespace WebAPIVk.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LetterFromPost> LetterFromPosts { get; set; }

    }
}
