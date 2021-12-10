using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Nation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NationType = table.Column<string>(nullable: true),
                    NationTypeDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Nation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<decimal>(nullable: false),
                    NationId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    BankAccountNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Customer_Tbl_Nation_NationId",
                        column: x => x.NationId,
                        principalTable: "Tbl_Nation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Customer_Email",
                table: "Tbl_Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Customer_NationId",
                table: "Tbl_Customer",
                column: "NationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Customer");

            migrationBuilder.DropTable(
                name: "Tbl_Nation");
        }
    }
}
