using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using Finance.Domain.Aggregates.LoanAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.LoanAggregate.Events
{

  /// <summary>
  /// Müşterinin Kredi isteği sonrasında kredi notu yeterli ise bu durumda kredi Onaylanmış oluyor ve yeni bir Loan kredi nesnesi üretilip, applyForCredit krediyi kullan methodu çağırılıyor
  /// ApplyForCredit de ise kredi müşterinin borç hanesine yazılıp, çekilen ana para müşterinin hesabına geçiyor. Bu işlemede loanSubmitted işlemi diyoruz.
  /// </summary>
  public class LoanApprovedHandler : INotificationHandler<LoanApproved>
  {
    // Müşterinin Kredisi onaylandıktan sonra
    // müşteri için yeni bir hesap açılışı yapılıp, bu hesaba ana para yatırılacak
    public async Task Handle(LoanApproved notification, CancellationToken cancellationToken)
    {

      var loan = new Loan(notification.LoanApplicationId, notification.LoanAmount, notification.CustomerId,notification.Term,notification.BankRate);

      loan.ApproveLoan(); // Kredi Onayından sonra kredi kullanımı yap.

    }
  }
}
