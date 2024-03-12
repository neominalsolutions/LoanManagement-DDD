
using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories;
using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations;
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
  /// Müşterinin hanesine para geçirmek için işlemleri başlatır.
  /// </summary>
  public class LoanSubmittedHandler : INotificationHandler<LoanSubmitted>
  {
    private readonly ILoanRepository loanRepository;
    private readonly IAccountOwnerRepository accountOwnerRepository;
    private readonly IAccountRepository accountRepository;
    private readonly IUnitOfWork unitOfWork;

    public LoanSubmittedHandler(ILoanRepository loanRepository, IAccountOwnerRepository accountOwnerRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
    {
      this.loanRepository = loanRepository;
      this.accountOwnerRepository = accountOwnerRepository;
      this.accountRepository = accountRepository;
      this.unitOfWork = unitOfWork;
    }

    public async Task Handle(LoanSubmitted notification, CancellationToken cancellationToken)
    {

      string bankAccountNumber = Guid.NewGuid().ToString();

      var accountOwner = accountOwnerRepository.Find(x => x.Id == notification.Loan.LoanCustomerId).FirstOrDefault();

      if(accountOwner is null)
      {
        accountOwner = new AccountOwner(customerId: notification.Loan.LoanCustomerId,AccountType.Personal);
        accountOwnerRepository.Create(accountOwner);
      }

      // müşteriye kredi hesap açılışı
      var customerAccount = accountOwner.OpenAccount(bankAccountNumber);

      customerAccount.IncomingTransfer(notification.Loan.PrincipalAmount, MoneyTransferChannel.Loan);

      // loan account number sonrasında set edildi, account aggregate'den loan aggregate geçiş.
      var loan = loanRepository.FindById(notification.Loan.Id);
      loan.SetLoanAccountNumber(bankAccountNumber);

    }
  }
}
