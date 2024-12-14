using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMS.Migrations
{
    /// <inheritdoc />
    public partial class AddDogsParksFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogPark");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogPark",
                columns: table => new
                {
                    DogsVisitedId = table.Column<int>(type: "int", nullable: false),
                    ParksVisitedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogPark", x => new { x.DogsVisitedId, x.ParksVisitedId });
                    table.ForeignKey(
                        name: "FK_DogPark_Dogs_DogsVisitedId",
                        column: x => x.DogsVisitedId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogPark_Parks_ParksVisitedId",
                        column: x => x.ParksVisitedId,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogPark_ParksVisitedId",
                table: "DogPark",
                column: "ParksVisitedId");
        }
    }
}
