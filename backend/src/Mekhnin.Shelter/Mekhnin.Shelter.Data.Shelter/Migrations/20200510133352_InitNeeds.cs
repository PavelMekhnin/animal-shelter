using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mekhnin.Shelter.Data.Shelter.Migrations
{
    public partial class InitNeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "needs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    count = table.Column<int>(nullable: false),
                    is_done = table.Column<bool>(nullable: false),
                    shelter_id = table.Column<int>(nullable: false),
                    animal_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_needs", x => x.id);
                    table.ForeignKey(
                        name: "FK_needs_animals_animal_id",
                        column: x => x.animal_id,
                        principalTable: "animals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_needs_shelters_shelter_id",
                        column: x => x.shelter_id,
                        principalTable: "shelters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_needs_animal_id",
                table: "needs",
                column: "animal_id");

            migrationBuilder.CreateIndex(
                name: "IX_needs_shelter_id",
                table: "needs",
                column: "shelter_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "needs");
        }
    }
}
