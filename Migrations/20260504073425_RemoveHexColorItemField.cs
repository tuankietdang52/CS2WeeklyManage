using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS2WeeklyManage.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHexColorItemField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HexColor",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HexColor",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
