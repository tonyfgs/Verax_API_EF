using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StubbedContextLib.Migrations
{
    /// <inheritdoc />
    public partial class mrg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleSet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DatePublished = table.Column<string>(type: "TEXT", nullable: false),
                    LectureTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pseudo = table.Column<string>(type: "TEXT", nullable: false),
                    Mdp = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleUserEntity",
                columns: table => new
                {
                    UserEntityId = table.Column<long>(type: "INTEGER", nullable: false),
                    ArticleEntityId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUserEntity", x => new { x.ArticleEntityId, x.UserEntityId });
                    table.ForeignKey(
                        name: "FK_ArticleUserEntity_ArticleSet_ArticleEntityId",
                        column: x => x.ArticleEntityId,
                        principalTable: "ArticleSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleUserEntity_UserSet_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Theme = table.Column<string>(type: "TEXT", nullable: false),
                    DatePublication = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    Pseudo = table.Column<string>(type: "TEXT", nullable: false),
                    UserEntityId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormEntity_UserSet_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "UserSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleSet",
                columns: new[] { "Id", "Author", "DatePublished", "Description", "LectureTime", "Title" },
                values: new object[,]
                {
                    { 1L, "Tom Smith", "2022-02-06", "The queen of England died today at the age of 95", 2, "Breaking News Elisabeth 2 Died" },
                    { 2L, "Tom Smith", "2022-02-06", "The new iPhone 15 is out and it's the best phone ever", 3, "The new iPhone 15" },
                    { 3L, "M&M's Red", "2022-02-06", "M&M's new recipe is out and it's the best chocolate ever", 1, "M&M's new recipe" }
                });

            migrationBuilder.InsertData(
                table: "UserSet",
                columns: new[] { "Id", "Mail", "Mdp", "Nom", "Prenom", "Pseudo", "Role" },
                values: new object[,]
                {
                    { 1L, "tony@gmail.com", "1234", "Fages", "Tony", "TonyF", "Admin" },
                    { 2L, "tom@mail.com", "1234", "Smith", "Tom", "TomS", "User" },
                    { 3L, "M&M#mail.com", "1234", "M&M's", "Red", "RedM", "Modérator" }
                });

            migrationBuilder.InsertData(
                table: "ArticleUserEntity",
                columns: new[] { "ArticleEntityId", "UserEntityId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 2L, 3L },
                    { 3L, 1L },
                    { 3L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUserEntity_UserEntityId",
                table: "ArticleUserEntity",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FormEntity_UserEntityId",
                table: "FormEntity",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleUserEntity");

            migrationBuilder.DropTable(
                name: "FormEntity");

            migrationBuilder.DropTable(
                name: "ArticleSet");

            migrationBuilder.DropTable(
                name: "UserSet");
        }
    }
}
