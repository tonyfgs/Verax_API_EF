using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbContextLib.Migrations
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
                    Pseudo = table.Column<string>(type: "TEXT", nullable: false),
                    Mdp = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSet", x => x.Pseudo);
                });

            migrationBuilder.CreateTable(
                name: "ArticleUserSet",
                columns: table => new
                {
                    UserEntityPseudo = table.Column<string>(type: "TEXT", nullable: false),
                    ArticleEntityId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUserSet", x => new { x.ArticleEntityId, x.UserEntityPseudo });
                    table.ForeignKey(
                        name: "FK_ArticleUserSet_ArticleSet_ArticleEntityId",
                        column: x => x.ArticleEntityId,
                        principalTable: "ArticleSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleUserSet_UserSet_UserEntityPseudo",
                        column: x => x.UserEntityPseudo,
                        principalTable: "UserSet",
                        principalColumn: "Pseudo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormSet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Theme = table.Column<string>(type: "TEXT", nullable: false),
                    DatePublication = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    UserEntityPseudo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSet_UserSet_UserEntityPseudo",
                        column: x => x.UserEntityPseudo,
                        principalTable: "UserSet",
                        principalColumn: "Pseudo",
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
                columns: new[] { "Pseudo", "Mail", "Mdp", "Nom", "Prenom", "Role" },
                values: new object[,]
                {
                    { "NoaSil", "", "1234", "Sillard", "Noa", "Admin" },
                    { "RedM", "M&M#mail.com", "1234", "M&M's", "Red", "Modérator" },
                    { "Sha", "ShaCasca@gmail.com", "1234", "Cascarra", "Cascarra", "Admin" },
                    { "TomS", "tom@mail.com", "1234", "Smith", "Tom", "User" },
                    { "TonyF", "tony@gmail.com", "1234", "Fages", "Tony", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "ArticleUserSet",
                columns: new[] { "ArticleEntityId", "UserEntityPseudo" },
                values: new object[,]
                {
                    { 1L, "TonyF" },
                    { 2L, "NoaSil" },
                    { 2L, "TomS" },
                    { 3L, "RedM" },
                    { 3L, "Sha" }
                });

            migrationBuilder.InsertData(
                table: "FormSet",
                columns: new[] { "Id", "DatePublication", "Link", "Theme", "UserEntityPseudo" },
                values: new object[,]
                {
                    { 1L, "Form 1 Description", "hhtp://form1.com", "Form 1 Theme", "Sha" },
                    { 2L, "Form 2 Description", "hhtp://form2.com", "Form 2 Theme", "Sha" },
                    { 3L, "Form 3 Description", "hhtp://form3.com", "Form 3 Theme", "Sha" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUserSet_UserEntityPseudo",
                table: "ArticleUserSet",
                column: "UserEntityPseudo");

            migrationBuilder.CreateIndex(
                name: "IX_FormSet_UserEntityPseudo",
                table: "FormSet",
                column: "UserEntityPseudo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleUserSet");

            migrationBuilder.DropTable(
                name: "FormSet");

            migrationBuilder.DropTable(
                name: "ArticleSet");

            migrationBuilder.DropTable(
                name: "UserSet");
        }
    }
}
