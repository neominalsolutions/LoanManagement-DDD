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
  public class EFLoanApplicationRepository : EFRepository<FinanceContext, LoanApplication, string>,ILoanApplicationRepository
  {
    public EFLoanApplicationRepository(FinanceContext db) : base(db)
    {
    }
  }
}
