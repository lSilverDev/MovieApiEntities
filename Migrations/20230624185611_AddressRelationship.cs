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
                table: "MovieTheaters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaters_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Address_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Address_AddressId",
                table: "MovieTheaters");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaters_AddressId",
                table: "MovieTheaters");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "MovieTheaters");
        }
    }
}
