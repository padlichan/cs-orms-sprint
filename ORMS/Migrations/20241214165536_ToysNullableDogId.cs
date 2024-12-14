using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORMS.Migrations
{
    /// <inheritdoc />
    public partial class ToysNullableDogId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Dogs_DogId",
                table: "Toys");

            migrationBuilder.AlterColumn<int>(
                name: "DogId",
                table: "Toys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Dogs_DogId",
                table: "Toys",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_Dogs_DogId",
                table: "Toys");

            migrationBuilder.AlterColumn<int>(
                name: "DogId",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_Dogs_DogId",
                table: "Toys",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
