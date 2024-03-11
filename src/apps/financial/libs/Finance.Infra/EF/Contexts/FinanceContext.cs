using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Domain.CustomerContext.Aggregates;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Infra.EF.Configurations.AccountContext;
using Finance.Infra.EF.Configurations.BankAccountAggregate;
using Finance.Infra.EF.Configurations.CustomerAggregate;
using Finance.Infra.EF.Configurations.LoanAggregate;
using Finance.Infra.MediaTR;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Contexts
{
    public class FinanceContext:DbContext
  {
    private readonly IMediator mediator;

    public DbSet<LoanApplication> LoanApplications { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<AccountOwner> AccountOwners { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<LoanCustomer> LoanCustomers { get; set; }

    public DbSet<Customer> Customers { get; set; }


    public FinanceContext(DbContextOptions<FinanceContext> opt, IMediator mediator):base(opt)
    {
      this.mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AccountConfig());
      modelBuilder.ApplyConfiguration(new AccountTransactionConfig());
      modelBuilder.ApplyConfiguration(new CustomerConfig());
      modelBuilder.ApplyConfiguration(new LoanApplicationConfig());
      modelBuilder.ApplyConfiguration(new LoanConfig());
      modelBuilder.ApplyConfiguration(new LoanDebtConfig());
      modelBuilder.ApplyConfiguration(new LoanCustomerConfig());
      modelBuilder.ApplyConfiguration(new AccountOwnerConfig());


      base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {

      await this.mediator.DispatchDomainEventsAsync(this);

      return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
  }
}
