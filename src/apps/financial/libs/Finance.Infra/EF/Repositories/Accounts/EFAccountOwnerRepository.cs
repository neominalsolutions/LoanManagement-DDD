using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories;
using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Infra.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Repositories.Accounts
{
  public class EFAccountOwnerRepository : EFRepository<FinanceContext, AccountOwner, string>, IAccountOwnerRepository
  {
    public EFAccountOwnerRepository(FinanceContext db) : base(db)
    {
    }
  }
}
