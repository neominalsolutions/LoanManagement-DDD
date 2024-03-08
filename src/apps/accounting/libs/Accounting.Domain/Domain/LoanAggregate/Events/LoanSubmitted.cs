using Accounting.Domain.Domain.CreditAggregate.Entities;
using Accounting.Domain.Domain.Shared.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.LoanAggregate.Events
{
  // Kredilendirildi.
  public class LoanSubmitted: INotification
  {

    public Loan Loan { get; init; }
    public LoanSubmitted(Loan loan)
    {
      Loan = loan;
    }


  }
}
