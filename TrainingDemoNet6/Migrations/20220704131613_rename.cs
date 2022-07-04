using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingDemoNet6.Migrations
{
    public partial class rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DIsplayOrder",
                table: "Categories",
                newName: "DisplayOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Categories",
                newName: "DIsplayOrder");
        }
    }
}
