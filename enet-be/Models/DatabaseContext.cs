using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enet_be.Models
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



            modelbuilder.Entity<AvailableOptions>().HasData(
               new AvailableOptions
               {
                   AvailableOptionsId = 1,
                   Content = "Test1"
               }
           );

            modelbuilder.Entity<AvailableOptions>().HasData(
               new AvailableOptions
               {
                   AvailableOptionsId = 2,
                   Content = "Test2"
               }
           );


            modelbuilder.Entity<Post>().HasData(
          new Post
          {
              PostId = 1,
              Type = "Type1",
              Url = "https://i.imgur.com/5NYlSWb.jpg",
              Content = "Good morning, guys!",
              Status = 1,
              IsExist = true,
              UserId = 1,
              AvailableOptionsId = 1
          }
      );

            modelbuilder.Entity<Post>().HasData(
          new Post
          {
              PostId = 2,
              Type = "Type1",
              Url = "https://i.imgur.com/5NYlSWb.jpg",
              Content = "Last night I dreamt of you my friend Of how you cried and said we intertwine",
              Status = 1,
              IsExist = true,
              UserId = 1,
              AvailableOptionsId = 1
          }
      );

            modelbuilder.Entity<Post>().HasData(
          new Post
          {
              PostId = 3,
              Type = "Type1",
              Url = "https://i.imgur.com/cEn7P4Q.jpg",
              Content = "Last night I dreamt of you my friend Of how you cried and said we intertwine",
              Status = 1,
              IsExist = true,
              UserId = 1,
              AvailableOptionsId = 1
          }
      );

            modelbuilder.Entity<Post>().HasData(
          new Post
          {
              PostId = 4,
              Type = "Type1",
              Url = "https://i.imgur.com/GvB85NNb.jpg",
              Content = "có chiếc xe cửa sổ trong veo đưa hồn ai bay đi qua vèo",
              Status = 1,
              IsExist = true,
              UserId = 1,
              AvailableOptionsId = 1
          }
      );

            modelbuilder.Entity<Post>().HasData(
         new Post
         {
             PostId = 5,
             Type = "Type1",
             Url = "https://i.imgur.com/5NYlSWb.jpg",
             Content = "Nắng vẫn rơi bên thềm, vương sỏi đá. Gió kéo mây đi rồi, bay về đâu ? ",
             Status = 1,
             IsExist = true,
             UserId = 1,
             AvailableOptionsId = 1
         }
     );

            modelbuilder.Entity<Post>().HasData(
         new Post
         {
             PostId = 6,
             Type = "Type1",
             Url = "https://i.imgur.com/5NYlSWb.jpg",
             Content = "Bắt xe tuyến vùng cao Đà Lạt Tách cà phê hương thơm ngào ngạt ",
             Status = 1,
             IsExist = true,
             UserId = 1,
             AvailableOptionsId = 1
         }
     );

            modelbuilder.Entity<Post>().HasData(
         new Post
         {
             PostId = 7,
             Type = "Type1",
             Url = "https://i.imgur.com/QHIc2NO.jpg",
             Content = "Bắt chuyến xe đò, tuyến vùng cao, ghé thành phố không đèn đỏ. Ngồi đón bình minh, nắng vàng son..lên thềm gỗ ",
             Status = 1,
             IsExist = true,
             UserId = 1,
             AvailableOptionsId = 1
         }
     );

            modelbuilder.Entity<Post>().HasData(
        new Post
        {
            PostId = 8,
            Type = "Type1",
            Url = "https://i.imgur.com/BzONxug.jpg",
            Content = "Đó là một trang sách cũ mùi, Năm tháng ngủ vùi. Hoen ố trong tim ai đủ rồi ! Ưu tư phũ trời ",
            Status = 1,
            IsExist = true,
            UserId = 1,
            AvailableOptionsId = 1
        }
    );

            modelbuilder.Entity<Post>().HasData(
        new Post
        {
            PostId = 9,
            Type = "Type1",
            Url = "https://i.imgur.com/BzONxug.jpg",
            Content = "Có một ngày, chót đem lòng ta ôm lấy cuồng si.. ",
            Status = 1,
            IsExist = true,
            UserId = 1,
            AvailableOptionsId = 1
        }
    );

            modelbuilder.Entity<Post>().HasData(
        new Post
        {
            PostId = 10,
            Type = "Type1",
            Url = "https://i.imgur.com/T5AmSfab.jpg",
            Content = "Anh vẫn hay đọc lại quyển sách đôi ta... từng xem. Vì còn bao điều thú vị ta vẫn chưa thể nào nhận ra...em à ",
            Status = 1,
            IsExist = true,
            UserId = 1,
            AvailableOptionsId = 1
        }
    );

            modelbuilder.Entity<Post>().HasData(
       new Post
       {
           PostId = 11,
           Type = "Type1",
           Url = "https://i.imgur.com/q5RUBHl.jpg",
           Content = "Hello! It's me ",
           Status = 1,
           IsExist = true,
           UserId = 1,
           AvailableOptionsId = 1
       }
   );

            modelbuilder.Entity<Reaction>().HasData(
      new Reaction
      {
          ReactionId = 1,
          PostId = 1,
          UserId = 1,
          Date = Convert.ToDateTime("1/1/2019"),
          Content = "Test1",
          Image = "https://i.imgur.com/q5RUBHl.jpg"
      }
  );

            modelbuilder.Entity<Relationship>().HasData(
     new Relationship
     {
         RelationshipId = 1,
         UserId = 1,
         UserSub = 2,
         Friend = true,
         Follow = true,
         Block = false
     }
 );

            modelbuilder.Entity<Relationship>().HasData(
    new Relationship
    {
        RelationshipId = 2,
        UserId = 2,
        UserSub = 1,
        Friend = true,
        Follow = true,
        Block = false
    }
);

            modelbuilder.Entity<Relationship>().HasData(
   new Relationship
   {
       RelationshipId = 3,
       UserId = 2,
       UserSub = 1,
       Friend = true,
       Follow = true,
       Block = false
   }
);

            modelbuilder.Entity<ReportType>().HasData(
   new ReportType
   {
       ReportTypeId = 1,
       ReportTypeName = "Type1"
   }
);

            modelbuilder.Entity<ReportType>().HasData(
  new ReportType
  {
      ReportTypeId = 2,
      ReportTypeName = "Type2"
  }
);

            modelbuilder.Entity<Report>().HasData(
  new Report
  {
      ReportId = 1,
      ReporterId = 1,
      Type = 1,
      ContentId = 1,
      BeReportedId = 1,
      Judge = 1,
      ReportDate = Convert.ToDateTime("1/1/2019"),
      ApproveDate = Convert.ToDateTime("1/1/2019"),
      Status = 1,
      Count = 1,
      PostId = 1,
      ReportTypeId = 1
  }
);
            modelbuilder.Entity<Role>().HasData(
 new Role
 {
     RoleId = 1,
     Type = "Admin"
 }
);

            modelbuilder.Entity<Role>().HasData(
 new Role
 {
     RoleId = 2,
     Type = "User"
 }
);

            modelbuilder.Entity<User>().HasData(
 new User
 {
     UserId = 1,
     UserName = "Lisa",
     FirstName = "Lisa",
     LastName = "Nguyen",
     Address = "Da Nang",
     Birthday = Convert.ToDateTime("8/22/2019"),
     PhoneNumber = "0764126148",
     Email = "lisa@enclave.vn",
     IsExist = true,
     Image = "https://i.imgur.com/q5RUBHl.jpg",
     RoleId = 1
 }
);

            modelbuilder.Entity<User>().HasData(
 new User
 {
     UserId = 2,
     UserName = "Anthorny",
     FirstName = "Anthorny",
     LastName = "Pham",
     Address = "DakNong",
     Birthday = Convert.ToDateTime("1/1/2019"),
     PhoneNumber = "0764126149",
     Email = "anthorny@enclave.vn",
     IsExist = true,
     Image = "https://i.imgur.com/q5RUBHl.jpg",
     RoleId = 1
 }
);

            modelbuilder.Entity<User>().HasData(
 new User
 {
     UserId = 3,
     UserName = "Dard",
     FirstName = "Dard",
     LastName = "Ngo",
     Address = "Da Nang",
     Birthday = Convert.ToDateTime("1/1/2019"),
     PhoneNumber = "0764126150",
     Email = "dard@enclave.vn",
     IsExist = true,
     Image = "https://i.imgur.com/q5RUBHl.jpg",
     RoleId = 1
 }
);

            modelbuilder.Entity<User>().HasData(
 new User
 {
     UserId = 4,
     UserName = "Jeremy",
     FirstName = "Jeremy",
     LastName = "Tran",
     Address = "Da Nang",
     Birthday = Convert.ToDateTime("1/1/2019"),
     PhoneNumber = "0764126151",
     Email = "jeremy@enclave.vn",
     IsExist = true,
     Image = "https://i.imgur.com/q5RUBHl.jpg",
     RoleId = 2
 }
);

            modelbuilder.Entity<User>().HasData(
 new User
 {
     UserId = 5,
     UserName = "Sunny",
     FirstName = "Sunny",
     LastName = "Nguyen",
     Address = "Da Nang",
     Birthday = Convert.ToDateTime("1/1/2019"),
     PhoneNumber = "0764126152",
     Email = "sunny@enclave.vn",
     IsExist = true,
     Image = "https://i.imgur.com/q5RUBHl.jpg",
     RoleId = 2
 }
);

            modelbuilder.Entity<Appeal>().HasData(
                          new Appeal
                          {
                              AppealId = 1,
                              Date = Convert.ToDateTime("1/1/2019"),
                              Status = 1,
                              ReportId = 1,
                              UserId = 1
                          }
                      );

            modelbuilder.Entity<Appeal>().HasData(
              new Appeal
              {
                  AppealId = 2,
                  Date = Convert.ToDateTime("11/1/2019"),
                  Status = 1,
                  ReportId = 1,
                  UserId = 1
              }
          );


            modelbuilder.Entity<Comment>().HasData(
               new Comment
               {
                   CommentId = 1,
                   Date = Convert.ToDateTime("1/1/2019"),
                   Content = "Thanks!",
                   IsExist = true,
                   UserId = 1,
                   PostId = 1
               }
           );

            modelbuilder.Entity<Comment>().HasData(
              new Comment
              {
                  CommentId = 2,
                  Date = Convert.ToDateTime("1/1/2019"),
                  Content = "I love you!",
                  IsExist = true,
                  UserId = 1,
                  PostId = 2
              }
          );

            modelbuilder.Entity<Content>().HasData(
             new Content
             {
                 ContentId = 1,
                 ContentName = "Test1",
                 UserId = 1
             }
         );

            modelbuilder.Entity<Content>().HasData(
             new Content
             {
                 ContentId = 2,
                 ContentName = "Test2",
                 UserId = 1
             }
         );

            modelbuilder.Entity<Expect>().HasData(
             new Expect
             {
                 UserIdMain = 1,
                 UserIdSub = 2
             }
         );

            modelbuilder.Entity<Log>().HasData(
            new Log
            {
                LogId = 1,
                Content = "Test1",
                ModifiedBy = "Lisa",
                ModifiedDate = Convert.ToDateTime("1/1/2019")
            }
        );

            modelbuilder.Entity<Log>().HasData(
            new Log
            {
                LogId = 2,
                Content = "Test2",
                ModifiedBy = "Anthorny",
                ModifiedDate = Convert.ToDateTime("1/1/2019")
            }
        );

            modelbuilder.Entity<Only>().HasData(
           new Only
           {
               UserIdMain = 1,
               UserIdSub = 2
           }
       );            
        }
    }
}
