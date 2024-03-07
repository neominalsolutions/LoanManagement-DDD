using Accounting.Domain.Domain.Shared.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.CreditAggregate.Events
{
  public class LoanApproved : INotification
  {
    public LoanApproved(string loanId, string customerId, Money limit)
    {
      LoanId = loanId;
      CustomerId = customerId;
      Limit = limit;
    }

    public string LoanId { get;  init; }
    public string CustomerId { get; init; }
    public Money Limit { get; init; } // Toplam Kredi Limiti


  }

}
