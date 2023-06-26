using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moviesAPI___Entities.Migrations
{
    public partial class AddressRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "MovieTheater",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheater_AddressId",
                table: "MovieTheater",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_Address_AddressId",
                table: "MovieTheater",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_Address_AddressId",
                table: "MovieTheater");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheater_AddressId",
                table: "MovieTheater");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "MovieTheater");
        }
    }
}
