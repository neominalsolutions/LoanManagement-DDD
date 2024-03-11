using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Infra.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Repositories.Accounts
{
  public class EFAccountRepository : EFRepository<FinanceContext, Account, string>, IAccountRepository
  {
    public EFAccountRepository(FinanceContext db) : base(db)
    {
    }
  }
}
