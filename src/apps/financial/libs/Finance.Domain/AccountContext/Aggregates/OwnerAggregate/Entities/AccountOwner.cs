using Domain.Core.Contracts;
using Finance.Domain.AccountContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Events;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities
{
  // Müşteriye ait Kredi Kartları, vadeli vadesiz hesaplar gibi alt nesneler bu aggregate üzerinden yönetilebilir.
  // Müşteriye tanımlı hesaplar,kredi kartları, varlıklar vs.
  // Banka Hesap Müşterisi
  public class AccountOwner : AggregateRoot
  {
    private List<Account> _accounts = new List<Account>();
    public IReadOnlyCollection<Account> Accounts => _accounts;

    public AccountType AccountType { get; private set; }

    public AccountOwner()
    {

    }

    public AccountOwner(string customerId, AccountType accountType)
    {
      Id = customerId;
      AccountType = accountType;
    }

    public Account OpenAccount(string accountNumber)
    {
      // Domain Event Fırlatalım
      var account = new Account(accountNumber, Id);
      _accounts.Add(account);

      var @event = new AccountOpened(accountNumber, Id);
      AddDomainEvent(@event);

      return account;
    }

    public void CloseAccount(string accountNumber, string closeReason)
    {
      // Domain Event Fırlatalım.
      var @event = new AccountClosed(accountNumber, closeReason);
      AddDomainEvent(@event);
    }

  }
}
