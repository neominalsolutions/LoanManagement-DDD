
using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Repositories;
using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Repositories;
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

    public LoanSubmittedHandler(ILoanRepository loanRepository, IAccountOwnerRepository accountOwnerRepository, IAccountRepository accountRepository)
    {
      this.loanRepository = loanRepository;
      this.accountOwnerRepository = accountOwnerRepository;
      this.accountRepository = accountRepository;
    }

    public async Task Handle(LoanSubmitted notification, CancellationToken cancellationToken)
    {

      string bankAccountNumber = Guid.NewGuid().ToString();

  
       var accountOwner = new AccountOwner(notification.Loan.LoanCustomerId, AccountType.Personal);
        // banka hesap müşterisi yoksa yeniden oluşturuldu. Yeni hesap müşteriye bağlandı
       accountOwnerRepository.Create(accountOwner);
      
      // müşteriye yeni hesap açılışını başlatık.
      var customerAccount = accountOwner.OpenAccount(bankAccountNumber);
      
      //// Kredideki hesap numarasını güncelledik.
      //notification.Loan.SetLoanAccountNumber(bankAccountNumber);
      //this.loanRepository.Update(notification.Loan);

      //// kredi tutarın hesaba geçmesini sağladık.
      //customerAccount.IncomingTransfer(notification.Loan.PrincipalAmount, MoneyTransferChannel.Loan);

      //// Para transefer işlemi veri tabanına yansıması için state değiştirdik.
      //this.accountRepository.Update(customerAccount);
    }
  }
}
