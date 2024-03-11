using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using Domain.Core.Contracts;
using Finance.Domain.Aggregates.AccountAggregate.Enumarations;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.AccountAggregate.Entities
{


    public class BankAccountTransaction : Entity<string>
  {
    public string Id { get; init; }
    public Money Money { get; init; }
    public BankAccountTransactionType Type { get; init; }
    public DateTime CreatedAt { get; init; }
    public string AccountId { get; set; }

    public string Via { get; init; } // Hangi Kanal ile para aktarılmış

    public MoneyTransferChannel TransferChannel { get; init; }

    public BankAccountTransaction()
    {

    }

    public BankAccountTransaction(string accountId, Money money, BankAccountTransactionType type, MoneyTransferChannel transferChannel)
    {
      Id = Guid.NewGuid().ToString();
      AccountId = accountId;
      Money = money;
      Type = type;
      CreatedAt = DateTime.Now;
      TransferChannel = transferChannel;
    }
  }
}
