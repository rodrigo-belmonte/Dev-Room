using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevRoom.Persistence.Migrations
{
    public partial class removeTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Technologies_TechnologyId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Libraries_Technologies_TechnologyId",
                table: "Libraries");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Technologies_TechnologyId",
                table: "Tips");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Tips_TechnologyId",
                table: "Tips");

            migrationBuilder.DropIndex(
                name: "IX_Libraries_TechnologyId",
                table: "Libraries");

            migrationBuilder.DropIndex(
                name: "IX_Contents_TechnologyId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Tips");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "IdTechnology",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Contents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TechnologyId",
                table: "Tips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TechnologyId",
                table: "Libraries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdTechnology",
                table: "Contents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TechnologyId",
                table: "Contents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LinkDocumentation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tips_TechnologyId",
                table: "Tips",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_TechnologyId",
                table: "Libraries",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_TechnologyId",
                table: "Contents",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Technologies_TechnologyId",
                table: "Contents",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Libraries_Technologies_TechnologyId",
                table: "Libraries",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Technologies_TechnologyId",
                table: "Tips",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
