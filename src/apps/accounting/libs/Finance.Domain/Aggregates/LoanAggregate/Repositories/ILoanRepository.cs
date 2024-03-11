
using Finance.Domain.Aggregates.LoanAggregate.Entities;
using Infra.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.LoanAggregate.Repositories
{
  public interface ILoanRepository:ICrudRepository<Loan, string>
  {

  }
}
