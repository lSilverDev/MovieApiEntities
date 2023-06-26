using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviesAPI___Entities.Migrations
{
    public partial class MovieAndMovieTheater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_MovieTheater_MovieTheaterId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.DropIndex(
                name: "IX_Session_MovieId",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Session");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                columns: new[] { "MovieId", "MovieTheaterId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Session_MovieTheater_MovieTheaterId",
                table: "Session",
                column: "MovieTheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_MovieTheater_MovieTheaterId",
                table: "Session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session",
                table: "Session");

            migrationBuilder.AlterColumn<int>(
                name: "MovieTheaterId",
                table: "Session",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session",
                table: "Session",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Session_MovieId",
                table: "Session",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_MovieTheater_MovieTheaterId",
                table: "Session",
                column: "MovieTheaterId",
                principalTable: "MovieTheater",
                principalColumn: "Id");
        }
    }
}
