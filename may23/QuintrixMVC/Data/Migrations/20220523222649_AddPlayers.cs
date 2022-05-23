using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuintrixMVC.Data.Migrations
{
    public partial class AddPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                    name: "Players",
                    columns: table => new {
                        Id = table.Column<Guid>(nullable: false),
                        Name = table.Column<string>(nullable: false),
                        Email = table.Column<string>(nullable: false)
                    },
                    constraints: table => {
                        table.PrimaryKey("PK_Player", item => item.Id);
                    });

            //Operation not supported by SQlite3:
            //migrationBuilder.AddPrimaryKey(name: "PK_Player", table: "Players", column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Players");
        }
    }
}
