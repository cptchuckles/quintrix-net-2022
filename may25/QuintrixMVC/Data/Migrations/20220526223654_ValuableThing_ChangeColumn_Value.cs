using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuintrixMVC.Data.Migrations
{
    public partial class ValuableThing_ChangeColumn_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "ValuableThing",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "Value",
                table: "ValuableThing",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
