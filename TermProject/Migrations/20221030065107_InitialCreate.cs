using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    OriginId = table.Column<string>(nullable: false),
                    Planet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.OriginId);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginId = table.Column<string>(nullable: false),
                    GenderId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "OriginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Sex" },
                values: new object[,]
                {
                    { "M", "Male" },
                    { "F", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "OriginId", "Planet" },
                values: new object[,]
                {
                    { "E", "Earth" },
                    { "M", "Mars" },
                    { "B", "Bellerophon" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Age", "Breed", "GenderId", "Name", "OriginId", "Weight" },
                values: new object[,]
                {
                    { 1, 2, "Bulldog", "F", "Daisy", "E", 45 },
                    { 3, 1, "Labrador", "M", "Bingo", "E", 60 },
                    { 4, 8, "Husky", "M", "Balto", "E", 55 },
                    { 2, 6, "Mix", "M", "Fido", "M", 30 },
                    { 5, 72, "blarphog", "M", "Meezork", "B", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_GenderId",
                table: "Dogs",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OriginId",
                table: "Dogs",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Origins");
        }
    }
}
