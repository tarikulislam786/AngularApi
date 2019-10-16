using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.CreateTable(
              name: "Users",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  Name = table.Column<string>(maxLength: 256, nullable: true),
                  CreatedDate = table.Column<DateTime>(nullable: true),
                  ModifiedDate = table.Column<DateTime>(nullable: true),
                  CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                  ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Users", x => x.Id);
              });

            migrationBuilder.CreateTable(
               name: "Calculations",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Num1 = table.Column<int>(nullable: false),
                   Num2 = table.Column<int>(nullable: false),
                   UserId = table.Column<int>(nullable: false),
                   Sum = table.Column<int>(nullable: false),
                   CreatedDate = table.Column<DateTime>(nullable: true),
                   ModifiedDate = table.Column<DateTime>(nullable: true),
                   CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                   ModifiedBy = table.Column<string>(maxLength: 256, nullable: true),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Calculations", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Calculations_Users_UserId",
                       column: x => x.UserId,
                       principalTable: "Users",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
            migrationBuilder.DropTable(
                name: "Calculations");

        }
    }
}
