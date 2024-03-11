using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
using Infra.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events
{

  /// <summary>
  /// Müşterinin Kredi isteği sonrasında kredi notu yeterli ise bu durumda kredi Onaylanmış oluyor ve yeni bir Loan kredi nesnesi üretilip, applyForCredit krediyi kullan methodu çağırılıyor
  /// ApplyForCredit de ise kredi müşterinin borç hanesine yazılıp, çekilen ana para müşterinin hesabına geçiyor. Bu işlemede loanSubmitted işlemi diyoruz.
  /// </summary>
  public class LoanApprovedHandler : INotificationHandler<LoanApproved>
  {
    // Müşterinin Kredisi onaylandıktan sonra
    // müşteri için yeni bir hesap açılışı yapılıp, bu hesaba ana para yatırılacak
    private readonly ILoanRepository loanRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMediator mediator;

    public LoanApprovedHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
      this.loanRepository = loanRepository;
      this.unitOfWork = unitOfWork;
      this.mediator = mediator;
    }

    public async Task Handle(LoanApproved notification, CancellationToken cancellationToken)
    {

      var loan = new Loan(notification.LoanApplication.Id, notification.LoanApplication.LoanAmount, notification.LoanApplication.LoanCustomerId, notification.LoanApplication.Term, notification.LoanApplication.BankRate, notification.LoanApplication.LoanType.Name);

      this.loanRepository.Create(loan);

    }
  }
}
