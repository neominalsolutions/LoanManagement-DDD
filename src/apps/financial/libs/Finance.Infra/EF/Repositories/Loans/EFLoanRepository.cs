using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
using Finance.Infra.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Repositories.Loans
{
  public class EFLoanRepository : EFRepository<FinanceContext, Loan, string>, ILoanRepository
  {
    public EFLoanRepository(FinanceContext db) : base(db)
    {
    }
  }
}
