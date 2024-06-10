using Microsoft.EntityFrameworkCore.Migrations;

namespace DevRoom.Persistence.Migrations
{
    public partial class addcolumnLinkedTagsInTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkedTags",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkedTags",
                table: "Tags");
        }
    }
}
