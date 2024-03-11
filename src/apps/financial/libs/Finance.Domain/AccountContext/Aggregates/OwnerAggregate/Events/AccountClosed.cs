using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Events
{
  public class AccountClosed:INotification
  {
    public string CustomerId { get; init; }
    public string CloseReason { get; init; }

    public AccountClosed(string customerId,string closeReason)
    {
      CustomerId = customerId;
      CloseReason = closeReason;
    }

  }
}
