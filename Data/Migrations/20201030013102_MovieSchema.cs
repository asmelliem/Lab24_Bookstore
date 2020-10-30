using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab24_Bookstore.Data.Migrations
{
    public partial class MovieSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckedOutMovieId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CheckedOutMovie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckedOutMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckedOutMovie_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CheckedOutMovieId",
                table: "Movie",
                column: "CheckedOutMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckedOutMovie_UserId",
                table: "CheckedOutMovie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_CheckedOutMovie_CheckedOutMovieId",
                table: "Movie",
                column: "CheckedOutMovieId",
                principalTable: "CheckedOutMovie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_CheckedOutMovie_CheckedOutMovieId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "CheckedOutMovie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CheckedOutMovieId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CheckedOutMovieId",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
