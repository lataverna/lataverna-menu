using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.LaTavernaMenu.Migrations
{
    /// <inheritdoc />
    public partial class DishEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAPorzione",
                table: "Dishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Dishes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAPorzione",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Dishes");
        }
    }
}
