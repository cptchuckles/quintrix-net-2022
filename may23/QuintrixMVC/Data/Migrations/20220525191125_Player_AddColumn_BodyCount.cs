using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuintrixMVC.Data.Migrations
{
    public partial class Player_AddColumn_BodyCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "BodyCount",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyCount",
                table: "Players");
        }
    }
}
