using Microsoft.EntityFrameworkCore.Migrations;

namespace DevRoom.Persistence.Migrations
{
    public partial class editContentTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Heading",
                table: "Contents",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Contents",
                newName: "Heading");
        }
    }
}
