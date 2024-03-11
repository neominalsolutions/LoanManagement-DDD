using Domain.Core.Contracts;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities
{
  public class Account : AggregateRoot
  {
    public string Id { get; init; }
    public string AccountNumber { get; private set; }
    public string AccountOwnerId { get; private set; }
    public Money Balance { get; private set; }

    public string CloseReason { get; private set; }

    public bool Closed { get; set; }

    public DateTime? ClosedAt { get; set; }



    private List<AccountTransaction> _transactions = new();
    public IReadOnlyCollection<AccountTransaction> Transactions => _transactions.AsReadOnly();

    public Account()
    {

    }

    public Account(string accountNumber, string customerId)
    {
      Id = Guid.NewGuid().ToString();
      AccountNumber = accountNumber;
      AccountOwnerId = customerId;
      Balance = new Money(0, "TL"); // Hesap ilk açılışta Balance 0 olur.
    }

    public void IncomingTransfer(Money money, MoneyTransferChannel transferChannel)
    {
      // DomainEvent

      Balance += money;

      _transactions.Add(new AccountTransaction(Id, money, AccountTransactionType.IncomingTransfer, transferChannel));
    }

  }
}
