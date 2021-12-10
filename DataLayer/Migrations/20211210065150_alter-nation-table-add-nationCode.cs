using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class alternationtableaddnationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NationCode",
                table: "Tbl_Nation",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tbl_Nation",
                columns: new[] { "Id", "NationCode", "NationType", "NationTypeDesc" },
                values: new object[] { 1, "+98", "IR", "IR(+98)" });

            migrationBuilder.InsertData(
                table: "Tbl_Nation",
                columns: new[] { "Id", "NationCode", "NationType", "NationTypeDesc" },
                values: new object[] { 2, "+1", "US", "US(+1)" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Nation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Nation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "NationCode",
                table: "Tbl_Nation");
        }
    }
}
