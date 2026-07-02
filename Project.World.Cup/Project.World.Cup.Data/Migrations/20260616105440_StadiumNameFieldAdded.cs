using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.World.Cup.Data.Migrations
{
    /// <inheritdoc />
    public partial class StadiumNameFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StadiumName",
                table: "Stadiums",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StadiumName",
                table: "Stadiums");
        }
    }
}
