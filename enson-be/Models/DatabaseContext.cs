using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enson_be.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ListUser> ListUsers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostVisibleOptions> PostVisibleOptions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relationship>()
                .HasKey(c => new { c.UserMain, c.UserSub });           
        }
    }
}
