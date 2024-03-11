using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Loan_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Loan_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnoulIncome_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnoulIncome_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loan_Type = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    BankRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principle_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Principle_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remaning_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remaning_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    BankRate = table.Column<double>(type: "float", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountTransaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Money_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transaction_Code = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferChannel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transafer_Channel_Code = table.Column<int>(type: "int", nullable: false),
                    BankAccountId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountTransaction_Accounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanDebt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Debt_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Debt_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDebt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDebt_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountTransaction_BankAccountId",
                table: "BankAccountTransaction",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDebt_LoanId",
                table: "LoanDebt",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountTransaction");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanDebt");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
