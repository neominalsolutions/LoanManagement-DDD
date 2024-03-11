using Finance.Domain.Aggregates.CustomerAggregate.Entities;
using Finance.Infra.EF.Contexts;
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

builder.Services.AddMediatR(opt =>
{
  opt.RegisterServicesFromAssemblyContaining<Customer>();
});

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
