using Accounting.Domain.Domain.AccountAggregate.Entities;
using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.CreditAggregate.Events
{
  public class LoanApprovedHandler : INotificationHandler<LoanApproved>
  {
    // Müşterinin Kredisi onaylandıktan sonra
    // müşteri için yeni bir hesap açılışı yapılıp, bu hesaba ana para yatırılacak
    public Task Handle(LoanApproved notification, CancellationToken cancellationToken)
    {

      var customerAccount = new CustomerAccount(Guid.NewGuid().ToString(), notification.CustomerId);

      customerAccount.Deposit(notification.Limit, TransferChannel.Loan);


      // kayıt sonrasında müşteriye bildirim gönder, mail at
      throw new NotImplementedException();
    }
  }
}
