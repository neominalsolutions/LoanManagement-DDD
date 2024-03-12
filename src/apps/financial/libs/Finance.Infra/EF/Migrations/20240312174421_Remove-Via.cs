using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class RemoveVia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Via",
                schema: "AccountContext",
                table: "AccountTransaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Via",
                schema: "AccountContext",
                table: "AccountTransaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
