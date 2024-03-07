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
  public class CustomerAccount:AggregateRoot
  {
    public string Id { get; init; }
    public string AccountNumber { get; private set; }
    public string CustomerId { get; private set; }
    public Money Balance { get; private set; }

    private List<CustomerAccountTransaction> _transactions = new();
    public IReadOnlyCollection<CustomerAccountTransaction> Transactions => _transactions.AsReadOnly();

    public CustomerAccount(string accountNumber, string customerId)
    {
      Id = Guid.NewGuid().ToString();
      AccountNumber = accountNumber;
      CustomerId = customerId;
      Balance = new Money(0, "TL");
    }

    public void Deposit(Money money, TransferChannel transferChannel)
    {
      // DomainEvent

      Balance += money;

      _transactions.Add(new CustomerAccountTransaction(Id, money, CustomerAccountTransactionType.Deposit));
    }

  }
}
