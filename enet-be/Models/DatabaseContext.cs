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
        // create table in SQLServer
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<AvailableOptions> AvailableOptions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Expect> Expects { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Only> Only { get; set; }
        public DbSet<OptionPostUser> OptionPostUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);           
            
            // table Comment has two foreign key: UserId, PostId
            modelbuilder.Entity<Comment>()
                .HasOne(e => e.User)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Comment>()
                .HasOne(e => e.Post)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // table Appeal has two foreign key: UserId, ReportId 
            modelbuilder.Entity<Appeal>()
                .HasOne(e => e.User)
                .WithMany(e => e.Appeals)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Appeal>()
                .HasOne(e => e.Report)
                .WithMany(e => e.Appeals)
                .HasForeignKey(e => e.ReportId)
                .OnDelete(DeleteBehavior.Restrict);

            // table OptionPostUser has two primary key: UserId and PostId
            modelbuilder.Entity<OptionPostUser>()
                .HasKey(e => new { e.UserId, e.PostId });
            
            modelbuilder.Entity<OptionPostUser>()
                .HasOne(e => e.Post)
                .WithMany(p => p.OptionPostUsers)
                .HasForeignKey(e => e.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<OptionPostUser>()
               .HasOne(e => e.User)
               .WithMany(p => p.OptionPostUsers)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Expect>()
                .HasKey(e => new { e.UserIdMain, e.UserIdSub });
            // table Expect have two primary key from table User so we have Expect1, Expect2, User1, User2.
            modelbuilder.Entity<Expect>()
                .HasOne(e => e.User1)
                .WithMany(e => e.Expects1)
                .HasConstraintName("Expect1")
                .HasForeignKey(e => e.UserIdMain)
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Expect>()
                .HasOne(e => e.User2)
                .WithMany(e => e.Expects2)
                .HasForeignKey(e => e.UserIdSub)
                .HasConstraintName("Expect2")
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Only>()
                .HasKey(e => new { e.UserIdMain, e.UserIdSub });

            modelbuilder.Entity<Only>()
                .HasOne(e => e.User1)
                .WithMany(e => e.Only1)
                .HasConstraintName("Only1")
                .HasForeignKey(e => e.UserIdMain)
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Only>()
                .HasOne(e => e.User2)
                .WithMany(e => e.Only2)
                .HasForeignKey(e => e.UserIdSub)
                .HasConstraintName("Only2")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
