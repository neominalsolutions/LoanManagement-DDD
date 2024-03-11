using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using Finance.Domain.Aggregates.AccountAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.LoanAggregate.Events
{
  /// <summary>
  /// Müşterinin hanesine para geçirmek için işlemleri başlatır.
  /// </summary>
  public class LoanSubmittedHandler : INotificationHandler<LoanSubmitted>
  {
    public async Task Handle(LoanSubmitted notification, CancellationToken cancellationToken)
    {

      string bankAccountNumber = Guid.NewGuid().ToString();

      var customerAccount = new BankAccount(bankAccountNumber, notification.Loan.CustomerId);

      notification.Loan.SetLoanAccountNumber(bankAccountNumber);

      customerAccount.IncomingTransfer(notification.Loan.PrincipalAmount, MoneyTransferChannel.Loan);

      
    }
  }
}
