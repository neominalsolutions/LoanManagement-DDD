using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance.Infra.EF.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AccountContext");

            migrationBuilder.EnsureSchema(
                name: "CustomerContext");

            migrationBuilder.EnsureSchema(
                name: "LoanContext");

            migrationBuilder.CreateTable(
                name: "AccountOwner",
                schema: "AccountContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Type_Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "CustomerContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplication",
                schema: "LoanContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Loan_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Loan_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoadCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_LoanApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanCustomer",
                schema: "LoanContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnnualIncome_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualIncome_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "AccountContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountOwner_AccountOwnerId",
                        column: x => x.AccountOwnerId,
                        principalSchema: "AccountContext",
                        principalTable: "AccountOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                schema: "LoanContext",
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
                    LoanCustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_LoanCustomer_LoanCustomerId",
                        column: x => x.LoanCustomerId,
                        principalSchema: "LoanContext",
                        principalTable: "LoanCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                schema: "AccountContext",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Money_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Money_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transaction_Code = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Via = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferChannel_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transafer_Channel_Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "AccountContext",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanDebt",
                schema: "LoanContext",
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
                        name: "FK_LoanDebt_Loan_LoanId",
                        column: x => x.LoanId,
                        principalSchema: "LoanContext",
                        principalTable: "Loan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountOwnerId",
                schema: "AccountContext",
                table: "Account",
                column: "AccountOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_AccountId",
                schema: "AccountContext",
                table: "AccountTransaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LoanCustomerId",
                schema: "LoanContext",
                table: "Loan",
                column: "LoanCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDebt_LoanId",
                schema: "LoanContext",
                table: "LoanDebt",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransaction",
                schema: "AccountContext");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "CustomerContext");

            migrationBuilder.DropTable(
                name: "LoanApplication",
                schema: "LoanContext");

            migrationBuilder.DropTable(
                name: "LoanDebt",
                schema: "LoanContext");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "AccountContext");

            migrationBuilder.DropTable(
                name: "Loan",
                schema: "LoanContext");

            migrationBuilder.DropTable(
                name: "AccountOwner",
                schema: "AccountContext");

            migrationBuilder.DropTable(
                name: "LoanCustomer",
                schema: "LoanContext");
        }
    }
}
