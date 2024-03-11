using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class LoanAccountNumberIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoanAccountNumber",
                schema: "LoanContext",
                table: "Loan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LoanAccountNumber",
                schema: "LoanContext",
                table: "Loan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
