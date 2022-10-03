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
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Sex" },
                values: new object[] { "M", "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Sex" },
                values: new object[] { "F", "Female" });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogId", "Age", "Breed", "GenderId", "Name", "Weight" },
                values: new object[,]
                {
                    { 2, 6, "Mix", "M", "Fido", 30 },
                    { 3, 1, "Labrador", "M", "Bingo", 60 },
                    { 4, 8, "Husky", "M", "Balto", 55 },
                    { 1, 2, "Bulldog", "F", "Daisy", 45 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_GenderId",
                table: "Dogs",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
