using Domain.Core.Contracts;
using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.AccountContext.Aggregates.AccountAggregate.Enumarations
{
  public class AccountType: Enumeration
  {
    // Kurumsal
    public static AccountType Corporate = new(1001, nameof(Corporate));

    // Bireysel
    public static AccountType Personal = new(1002, nameof(Personal));

    // Tüzel
    public static AccountType Business = new(1002, nameof(Business));


    public AccountType(int id, string name)
            : base(id, name)
    {
    }
  }
}
