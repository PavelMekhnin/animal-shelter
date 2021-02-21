using Microsoft.EntityFrameworkCore.Migrations;

namespace Mekhnin.Shelter.Data.Shelter.Migrations
{
    public partial class AddSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "volunteers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "shelters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "needs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "contacts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "animals",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "volunteers");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "shelters");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "needs");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "animals");
        }
    }
}
