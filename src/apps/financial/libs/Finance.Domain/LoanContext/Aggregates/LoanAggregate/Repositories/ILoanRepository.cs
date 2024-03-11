using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Infra.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories
{
    public interface ILoanRepository : ICrudRepository<Loan, string>
    {

    }
}
