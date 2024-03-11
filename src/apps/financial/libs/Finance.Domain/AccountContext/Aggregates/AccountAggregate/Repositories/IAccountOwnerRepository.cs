using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Infra.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories
{
  public interface IAccountOwnerRepository: ICrudRepository<AccountOwner, string>
  {
  }
}
