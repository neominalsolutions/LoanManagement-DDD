using Accounting.Domain.Domain.CreditAggregate.Entities;
using Infra.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.LoanAggregate.Repositories
{
  public interface ILoanRepository:ICrudRepository<Loan, string>
  {

  }
}
