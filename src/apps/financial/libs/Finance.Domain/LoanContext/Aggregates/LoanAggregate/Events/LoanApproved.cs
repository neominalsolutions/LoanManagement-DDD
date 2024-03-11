using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Domain.Shared.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events
{
  public class LoanApproved : INotification
  {
    public LoanApplication LoanApplication { get; init; }
    public LoanApproved(LoanApplication loanApplication)
    {
      this.LoanApplication = loanApplication;
    }

  }

}
