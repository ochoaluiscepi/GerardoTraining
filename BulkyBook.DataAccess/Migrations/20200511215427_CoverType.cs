using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class CoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false),
                    InsertedBy = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverType");
        }
    }
}
