using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace enet_be.Migrations
{
    public partial class initialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableOptions",
                columns: table => new
                {
                    AvailableOptionsId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableOptions", x => x.AvailableOptionsId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    ReportTypeId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReportTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsExist = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ContentName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expects",
                columns: table => new
                {
                    UserIdMain = table.Column<long>(nullable: false),
                    UserIdSub = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expects", x => new { x.UserIdMain, x.UserIdSub });
                    table.ForeignKey(
                        name: "Expect1",
                        column: x => x.UserIdMain,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Expect2",
                        column: x => x.UserIdSub,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Only",
                columns: table => new
                {
                    UserIdMain = table.Column<long>(nullable: false),
                    UserIdSub = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Only", x => new { x.UserIdMain, x.UserIdSub });
                    table.ForeignKey(
                        name: "Only1",
                        column: x => x.UserIdMain,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Only2",
                        column: x => x.UserIdSub,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    IsExist = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    AvailableOptionsId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_AvailableOptions_AvailableOptionsId",
                        column: x => x.AvailableOptionsId,
                        principalTable: "AvailableOptions",
                        principalColumn: "AvailableOptionsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(nullable: false),
                    UserSub = table.Column<long>(nullable: false),
                    Friend = table.Column<bool>(nullable: true),
                    Follow = table.Column<bool>(nullable: true),
                    Block = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_Relationships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsExist = table.Column<bool>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    PostId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionPostUsers",
                columns: table => new
                {
                    PostId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionPostUsers", x => new { x.UserId, x.PostId });
                    table.UniqueConstraint("AK_OptionPostUsers_PostId_UserId", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_OptionPostUsers_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionPostUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    ReactionId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PostId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.ReactionId);
                    table.ForeignKey(
                        name: "FK_Reactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReporterId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    ContentId = table.Column<long>(nullable: false),
                    BeReportedId = table.Column<long>(nullable: false),
                    Judge = table.Column<long>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: true),
                    ApproveDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    PostId = table.Column<long>(nullable: false),
                    ReportTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_ReportTypes_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportTypes",
                        principalColumn: "ReportTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appeals",
                columns: table => new
                {
                    AppealId = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    ReportId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appeals", x => x.AppealId);
                    table.ForeignKey(
                        name: "FK_Appeals_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appeals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AvailableOptions",
                columns: new[] { "AvailableOptionsId", "Content" },
                values: new object[,]
                {
                    { 1L, "Test1" },
                    { 2L, "Test2" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "LogId", "Content", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, "Test1", "Lisa", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Test2", "Anthorny", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ReportTypes",
                columns: new[] { "ReportTypeId", "ReportTypeName" },
                values: new object[,]
                {
                    { 1L, "Type1" },
                    { 2L, "Type2" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Type" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Birthday", "Email", "FirstName", "Image", "IsExist", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1L, "Da Nang", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa@enclave.vn", "Lisa", "https://i.imgur.com/q5RUBHl.jpg", true, "Nguyen", null, null, "0764126148", 1L, "Lisa" },
                    { 2L, "DakNong", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "anthorny@enclave.vn", "Anthorny", "https://i.imgur.com/q5RUBHl.jpg", true, "Pham", null, null, "0764126149", 1L, "Anthorny" },
                    { 3L, "Da Nang", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dard@enclave.vn", "Dard", "https://i.imgur.com/q5RUBHl.jpg", true, "Ngo", null, null, "0764126150", 1L, "Dard" },
                    { 4L, "Da Nang", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jeremy@enclave.vn", "Jeremy", "https://i.imgur.com/q5RUBHl.jpg", true, "Tran", null, null, "0764126151", 2L, "Jeremy" },
                    { 5L, "Da Nang", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sunny@enclave.vn", "Sunny", "https://i.imgur.com/q5RUBHl.jpg", true, "Nguyen", null, null, "0764126152", 2L, "Sunny" }
                });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "ContentId", "ContentName", "UserId" },
                values: new object[,]
                {
                    { 1L, "Test1", 1L },
                    { 2L, "Test2", 1L }
                });

            migrationBuilder.InsertData(
                table: "Expects",
                columns: new[] { "UserIdMain", "UserIdSub" },
                values: new object[] { 1L, 2L });

            migrationBuilder.InsertData(
                table: "Only",
                columns: new[] { "UserIdMain", "UserIdSub" },
                values: new object[] { 1L, 2L });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AvailableOptionsId", "Content", "IsExist", "Status", "Type", "Url", "UserId" },
                values: new object[,]
                {
                    { 11L, 1L, "Hello! It's me ", true, 1, "Type1", "https://i.imgur.com/q5RUBHl.jpg", 1L },
                    { 10L, 1L, "Anh vẫn hay đọc lại quyển sách đôi ta... từng xem. Vì còn bao điều thú vị ta vẫn chưa thể nào nhận ra...em à ", true, 1, "Type1", "https://i.imgur.com/T5AmSfab.jpg", 1L },
                    { 9L, 1L, "Có một ngày, chót đem lòng ta ôm lấy cuồng si.. ", true, 1, "Type1", "https://i.imgur.com/BzONxug.jpg", 1L },
                    { 8L, 1L, "Đó là một trang sách cũ mùi, Năm tháng ngủ vùi. Hoen ố trong tim ai đủ rồi ! Ưu tư phũ trời ", true, 1, "Type1", "https://i.imgur.com/BzONxug.jpg", 1L },
                    { 7L, 1L, "Bắt chuyến xe đò, tuyến vùng cao, ghé thành phố không đèn đỏ. Ngồi đón bình minh, nắng vàng son..lên thềm gỗ ", true, 1, "Type1", "https://i.imgur.com/QHIc2NO.jpg", 1L },
                    { 6L, 1L, "Bắt xe tuyến vùng cao Đà Lạt Tách cà phê hương thơm ngào ngạt ", true, 1, "Type1", "https://i.imgur.com/5NYlSWb.jpg", 1L },
                    { 5L, 1L, "Nắng vẫn rơi bên thềm, vương sỏi đá. Gió kéo mây đi rồi, bay về đâu ? ", true, 1, "Type1", "https://i.imgur.com/5NYlSWb.jpg", 1L },
                    { 4L, 1L, "có chiếc xe cửa sổ trong veo đưa hồn ai bay đi qua vèo", true, 1, "Type1", "https://i.imgur.com/GvB85NNb.jpg", 1L },
                    { 3L, 1L, "Last night I dreamt of you my friend Of how you cried and said we intertwine", true, 1, "Type1", "https://i.imgur.com/cEn7P4Q.jpg", 1L },
                    { 2L, 1L, "Last night I dreamt of you my friend Of how you cried and said we intertwine", true, 1, "Type1", "https://i.imgur.com/5NYlSWb.jpg", 1L },
                    { 1L, 1L, "Good morning, guys!", true, 1, "Type1", "https://i.imgur.com/5NYlSWb.jpg", 1L }
                });

            migrationBuilder.InsertData(
                table: "Relationships",
                columns: new[] { "RelationshipId", "Block", "Follow", "Friend", "UserId", "UserSub" },
                values: new object[,]
                {
                    { 1L, false, true, true, 1L, 2L },
                    { 2L, false, true, true, 2L, 1L },
                    { 3L, false, true, true, 2L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Content", "Date", "Image", "IsExist", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1L, "Thanks!", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 1L, 1L },
                    { 2L, "I love you!", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, 2L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "ReactionId", "Content", "Date", "Image", "PostId", "UserId" },
                values: new object[] { 1L, "Test1", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.imgur.com/q5RUBHl.jpg", 1L, 1L });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "ApproveDate", "BeReportedId", "ContentId", "Count", "Judge", "PostId", "ReportDate", "ReportTypeId", "ReporterId", "Status", "Type", "UserId" },
                values: new object[] { 1L, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, 1, 1L, 1L, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, 1, 1, null });

            migrationBuilder.InsertData(
                table: "Appeals",
                columns: new[] { "AppealId", "Date", "ReportId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1, 1L },
                    { 2L, new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_ReportId",
                table: "Appeals",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_UserId",
                table: "Appeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                table: "Contents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expects_UserIdSub",
                table: "Expects",
                column: "UserIdSub");

            migrationBuilder.CreateIndex(
                name: "IX_Only_UserIdSub",
                table: "Only",
                column: "UserIdSub");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AvailableOptionsId",
                table: "Posts",
                column: "AvailableOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId",
                table: "Reactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_UserId",
                table: "Relationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ContentId",
                table: "Reports",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PostId",
                table: "Reports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportTypeId",
                table: "Reports",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appeals");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Expects");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Only");

            migrationBuilder.DropTable(
                name: "OptionPostUsers");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "ReportTypes");

            migrationBuilder.DropTable(
                name: "AvailableOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
