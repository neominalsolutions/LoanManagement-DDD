using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories;
using Finance.Domain.CustomerContext.Aggregates;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Services;
using Finance.Infra.EF.Contexts;
using Finance.Infra.EF.Repositories.Accounts;
using Finance.Infra.EF.Repositories.Loans;
using Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FinanceContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("FinanceConn"));
});

builder.Services.AddScoped<ILoanRepository, EFLoanRepository>();
builder.Services.AddScoped<ILoanApplicationRepository, EFLoanApplicationRepository>();
builder.Services.AddScoped<ILoanCustomerRepository, EFLoanCustomerRepository>();
builder.Services.AddScoped<IAccountRepository, EFAccountRepository>();
builder.Services.AddScoped<IAccountOwnerRepository, EFAccountOwnerRepository>();

builder.Services.AddScoped<IUnitOfWork, FinanceContextUnitOfWork>();

builder.Services.AddMediatR(opt =>
{
  opt.RegisterServicesFromAssemblyContaining<Customer>();
});

builder.Services.AddScoped<CreditScoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
