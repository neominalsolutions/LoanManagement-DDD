using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Events
{
  public class AccountOpenedHandler : INotificationHandler<AccountOpened>
  {
    public async Task Handle(AccountOpened notification, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
    }
  }
}
