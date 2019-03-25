﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using enson_be.Models;

namespace enson_be.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("enson_be.Models.Appeal", b =>
                {
                    b.Property<long>("AppealId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<long>("ReportId");

                    b.Property<int>("Status");

                    b.Property<long>("UserId");

                    b.HasKey("AppealId");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("Appeals");
                });

            modelBuilder.Entity("enson_be.Models.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Image");

                    b.Property<long>("PostId");

                    b.Property<long>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("enson_be.Models.Content", b =>
                {
                    b.Property<long>("ContentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentName");

                    b.Property<long>("UserId");

                    b.HasKey("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("enson_be.Models.ListUser", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("Except");

                    b.Property<string>("Only");

                    b.HasKey("UserId");

                    b.ToTable("ListUsers");
                });

            modelBuilder.Entity("enson_be.Models.Log", b =>
                {
                    b.Property<long>("LogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("LogId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("enson_be.Models.Post", b =>
                {
                    b.Property<long>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("Status");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.Property<long>("UserId");

                    b.Property<string>("VisibleOptions");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("enson_be.Models.PostVisibleOptions", b =>
                {
                    b.Property<long>("PostId");

                    b.Property<string>("ListUser");

                    b.HasKey("PostId");

                    b.ToTable("PostVisibleOptions");
                });

            modelBuilder.Entity("enson_be.Models.Reaction", b =>
                {
                    b.Property<long>("ReactionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Image");

                    b.Property<long>("PostId");

                    b.Property<long>("UserId");

                    b.HasKey("ReactionId");

                    b.HasIndex("PostId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("enson_be.Models.Relationship", b =>
                {
                    b.Property<long>("RelationshipId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Block");

                    b.Property<bool>("Follow");

                    b.Property<bool>("Friend");

                    b.Property<long>("UserId");

                    b.Property<long>("UserSub");

                    b.HasKey("RelationshipId");

                    b.HasIndex("UserId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("enson_be.Models.Report", b =>
                {
                    b.Property<long>("ReportId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApproveDate");

                    b.Property<long>("BeReportedId");

                    b.Property<long>("ContentId");

                    b.Property<int>("Count");

                    b.Property<long>("Judge");

                    b.Property<long?>("PostId");

                    b.Property<DateTime>("ReportDate");

                    b.Property<long>("ReporterId");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<long?>("UserId");

                    b.HasKey("ReportId");

                    b.HasIndex("ContentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("enson_be.Models.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("enson_be.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<long>("RoleId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("enson_be.Models.Appeal", b =>
                {
                    b.HasOne("enson_be.Models.Report", "Report")
                        .WithMany("Appeals")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Appeals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("enson_be.Models.Comment", b =>
                {
                    b.HasOne("enson_be.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("enson_be.Models.Content", b =>
                {
                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Contents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.ListUser", b =>
                {
                    b.HasOne("enson_be.Models.User", "User")
                        .WithOne("ListUser")
                        .HasForeignKey("enson_be.Models.ListUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.Post", b =>
                {
                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.PostVisibleOptions", b =>
                {
                    b.HasOne("enson_be.Models.Post", "Post")
                        .WithOne("PostVisibleOptions")
                        .HasForeignKey("enson_be.Models.PostVisibleOptions", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.Reaction", b =>
                {
                    b.HasOne("enson_be.Models.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.Relationship", b =>
                {
                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Relationships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("enson_be.Models.Report", b =>
                {
                    b.HasOne("enson_be.Models.Content", "Content")
                        .WithMany("Reports")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("enson_be.Models.Post", "Post")
                        .WithMany("Reports")
                        .HasForeignKey("PostId");

                    b.HasOne("enson_be.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("enson_be.Models.User", b =>
                {
                    b.HasOne("enson_be.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
