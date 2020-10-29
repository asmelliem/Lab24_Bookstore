using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab24_Bookstore.Data.Migrations
{
    public partial class CreateMovieSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Runtime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Genre", "Runtime", "Title" },
                values: new object[,]
                {
                    { 1, "Comedy", 119.0, "Jumanji: Welcome to the Jungle" },
                    { 2, "Comedy", 123.0, "Jumanji: The Next Level" },
                    { 3, "Action", 133.0, "Spider-Man: Homecoming" },
                    { 4, "Action", 130.0, "John Wick: Chapter 3" },
                    { 5, "Action", 112.0, "Venom" },
                    { 6, "Action", 141.0, "Logan" },
                    { 7, "Horror", 94.0, "The Grudge" },
                    { 8, "Horror", 170.0, "It: Chapter Two" },
                    { 9, "Horror", 112.0, "The Conjuring" },
                    { 10, "Mystery", 130.0, "Knives Out" },
                    { 11, "Mystery", 114.0, "Murder on the Orient Express" },
                    { 12, "Documentary", 94.0, "The Social Dilemma" },
                    { 13, "Documentary", 97.0, "The Fight" },
                    { 14, "Musical", 106.0, "The Greated Showman" },
                    { 15, "Musical", 122.0, "Rocketman" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
