using Finance.Domain.Aggregates.AccountAggregate.Entities;
using Finance.Domain.Aggregates.CustomerAggregate.Entities;
using Finance.Domain.Aggregates.LoanAggregate.Entities;
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
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BankAccount> Accounts { get; set; }


    public FinanceContext(DbContextOptions<FinanceContext> opt, IMediator mediator):base(opt)
    {
      this.mediator = mediator;
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {

      await this.mediator.DispatchDomainEventsAsync(this);

      return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
  }
}
