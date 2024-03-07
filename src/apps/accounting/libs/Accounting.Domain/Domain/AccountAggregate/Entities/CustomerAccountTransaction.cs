using Accounting.Domain.Domain.AccountAggregate.Enumarations;
using Accounting.Domain.Domain.Shared.ValueObjects;
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.AccountAggregate.Entities
{


  public class CustomerAccountTransaction : Entity<string>
  {
    public string Id { get; init; }
    public Money Money { get; init; }
    public CustomerAccountTransactionType Type { get; init; }
    public DateTime CreatedAt { get; init; }
    public string AccountId { get; set; }

    public CustomerAccountTransaction()
    {

    }

    public CustomerAccountTransaction(string accountId, Money money, CustomerAccountTransactionType type)
    {
      Id = Guid.NewGuid().ToString();
      AccountId = accountId;
      Money = money;
      Type = type;
      CreatedAt = DateTime.Now;
    }
  }
}
