using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exam.DAL.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Students> Students { get; set; }

        public DbSet<Exams> Exams { get; set; }
    }
}
