using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Events
{
  public class AccountOpened:INotification
  {
    public string AccountNumber { get; init; }
    public string CustomerId { get; init; }
    public AccountOpened(string accountNumber, string CustomerId)
    {
      AccountNumber = accountNumber;
      CustomerId = CustomerId;
    }
  }
}
