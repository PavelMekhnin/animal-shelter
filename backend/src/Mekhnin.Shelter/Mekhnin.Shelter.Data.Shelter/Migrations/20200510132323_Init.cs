using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mekhnin.Shelter.Data.Shelter.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shelters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    logo_url = table.Column<string>(nullable: true),
                    cover_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    bio = table.Column<string>(nullable: true),
                    race = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    img_url = table.Column<string>(nullable: true),
                    shelter_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.id);
                    table.ForeignKey(
                        name: "FK_animals_shelters_shelter_id",
                        column: x => x.shelter_id,
                        principalTable: "shelters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animals_shelter_id",
                table: "animals",
                column: "shelter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "shelters");
        }
    }
}
