using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class LoanCustomerIdChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoadCustomerId",
                schema: "LoanContext",
                table: "LoanApplication",
                newName: "LoanCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanCustomerId",
                schema: "LoanContext",
                table: "LoanApplication",
                newName: "LoadCustomerId");
        }
    }
}
