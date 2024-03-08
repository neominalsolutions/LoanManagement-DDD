using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using Accounting.Domain.Domain.CustomerAggregate.Entities;
using Accounting.Domain.Domain.Shared.ValueObjects;
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Accounting.Domain.Domain.AccountAggregate.Entities
{
  public class BankAccount:AggregateRoot
  {
    public string Id { get; init; }
    public string AccountNumber { get; private set; }
    public string CustomerId { get; private set; }
    public Money Balance { get; private set; }

    private List<BankAccountTransaction> _transactions = new();
    public IReadOnlyCollection<BankAccountTransaction> Transactions => _transactions.AsReadOnly();

    public BankAccount(string accountNumber, string customerId)
    {
      Id = Guid.NewGuid().ToString();
      AccountNumber = accountNumber;
      CustomerId = customerId;
      Balance = new Money(0, "TL"); // Hesap ilk açılışta Balance 0 olur.
    }

    public void IncomingTransfer(Money money, MoneyTransferChannel transferChannel)
    {
      // DomainEvent

      Balance += money;

      _transactions.Add(new BankAccountTransaction(Id, money, BankAccountTransactionType.IncomingTransfer,transferChannel));
    }

  }
}
