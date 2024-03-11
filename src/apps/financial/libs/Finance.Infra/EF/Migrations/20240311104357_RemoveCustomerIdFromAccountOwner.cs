using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class RemoveCustomerIdFromAccountOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "AccountContext",
                table: "AccountOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                schema: "AccountContext",
                table: "AccountOwner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
