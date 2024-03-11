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
  public class EFLoanCustomerRepository : EFRepository<FinanceContext, LoanCustomer, string>,ILoanCustomerRepository
  {
    public EFLoanCustomerRepository(FinanceContext db) : base(db)
    {
    }
  }
}
