using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuintrixMVC.Data.Migrations
{
    public partial class CreateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("b730f5a4-8c65-4cd1-8132-a0668957b57a"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("ca19ddd0-8931-4750-9e1d-81cb611eeabf"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("cad8d3a6-945c-4c85-ab9f-c4437fece43a"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("dca7e89b-707d-4532-b9c5-b0a1e215db73"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("059be5ab-0260-4672-89da-1791541b8d54"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("2126fa6c-ccc4-48e4-a0c5-8031172b8214"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("8ec4a1e1-3695-4f1a-9c57-0ebd43b68b3c"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("d8bffbec-9394-4983-9db2-b8874ec42b4e"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("e1f77e87-187e-4d19-b7d3-b3788ad8188a"));

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("75291f86-de26-4fce-87de-358890f49445"), "A piddly thing of no value whatsoever.", "Trash 2" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("a2712464-38b1-47b9-8c3f-768197a870de"), "A piddly thing of no value whatsoever.", "Trash 1" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("e6ec9910-a2b2-4ed8-b0bb-4ca7b3b40236"), "A piddly thing of no value whatsoever.", "Trash 3" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("e8c9baef-efee-45e1-bdb1-f3558f4072b4"), "A piddly thing of no value whatsoever.", "Trash 4" });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("07d3d98f-9ca1-4bae-bb20-1c4588d3a89f"), "A jar of raspberry jam.", "Jam Jar", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("419e2d1a-8d52-449c-bd44-ce5f9d1c62b2"), "The comb of Wongo Tigmeus the Third", "Mr. Goodpart", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("5d65e0f2-fb70-42de-ac37-fc748dbbfdc5"), "Your mother's phone number.", "Trade Secret", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("a7bf4d61-61fc-4ed4-a0da-f4d8238b940d"), "Sail boat suitable for Niagra Falls.", "Barrel", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("b83f2fcb-4105-4455-95c0-f99e2f8d6caf"), "A very shiny rock.", "Shiny Rock", 5000000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("75291f86-de26-4fce-87de-358890f49445"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("a2712464-38b1-47b9-8c3f-768197a870de"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("e6ec9910-a2b2-4ed8-b0bb-4ca7b3b40236"));

            migrationBuilder.DeleteData(
                table: "PiddlyThing",
                keyColumn: "Id",
                keyValue: new Guid("e8c9baef-efee-45e1-bdb1-f3558f4072b4"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("07d3d98f-9ca1-4bae-bb20-1c4588d3a89f"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("419e2d1a-8d52-449c-bd44-ce5f9d1c62b2"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("5d65e0f2-fb70-42de-ac37-fc748dbbfdc5"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("a7bf4d61-61fc-4ed4-a0da-f4d8238b940d"));

            migrationBuilder.DeleteData(
                table: "ValuableThing",
                keyColumn: "Id",
                keyValue: new Guid("b83f2fcb-4105-4455-95c0-f99e2f8d6caf"));

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b730f5a4-8c65-4cd1-8132-a0668957b57a"), "A piddly thing of no value whatsoever.", "Spergus2" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("ca19ddd0-8931-4750-9e1d-81cb611eeabf"), "A piddly thing of no value whatsoever.", "Spergus1" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("cad8d3a6-945c-4c85-ab9f-c4437fece43a"), "A piddly thing of no value whatsoever.", "Spergus4" });

            migrationBuilder.InsertData(
                table: "PiddlyThing",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("dca7e89b-707d-4532-b9c5-b0a1e215db73"), "A piddly thing of no value whatsoever.", "Spergus3" });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("059be5ab-0260-4672-89da-1791541b8d54"), "The comb of Wongo Tigmeus the Third", "Shiny Rock 4", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("2126fa6c-ccc4-48e4-a0c5-8031172b8214"), "Barrel", "Shiny Rock 3", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("8ec4a1e1-3695-4f1a-9c57-0ebd43b68b3c"), "Your mother's phone number.", "Shiny Rock 5", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("d8bffbec-9394-4983-9db2-b8874ec42b4e"), "A very shiny rock.", "Shiny Rock 1", 5000000m });

            migrationBuilder.InsertData(
                table: "ValuableThing",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[] { new Guid("e1f77e87-187e-4d19-b7d3-b3788ad8188a"), "A jar of raspberry jam.", "Shiny Rock 2", 5000000m });
        }
    }
}
