using InventoryAppEFCore.DataLayer.EfClasses;
using InventoryAppEFCore.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAppEFCore.DataLayer.Migrations
{
    public partial class AddView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddViewViaSql<MyView>("EntityFilterView", "Reviews", "NumStars >= 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EntityFilterView");
        }
    }
}
