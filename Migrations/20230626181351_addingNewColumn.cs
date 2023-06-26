using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviesAPI___Entities.Migrations
{
    public partial class addingNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_MovieTheaterId",
                table: "Session",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_MovieTheaters_MovieTheaterId",
                table: "Session",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_MovieTheaters_MovieTheaterId",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_MovieTheaterId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "Session");
        }
    }
}
