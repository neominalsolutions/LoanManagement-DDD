using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Infra.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories
{
  public interface IAccountRepository: ICrudRepository<Account, string>
  {

  }
}
