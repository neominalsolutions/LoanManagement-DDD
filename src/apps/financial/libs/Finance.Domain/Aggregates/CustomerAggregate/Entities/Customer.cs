using Domain.Core.Contracts;
using Finance.Domain.Aggregates.AccountAggregate.Entities;
using Finance.Domain.Aggregates.LoanAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.CustomerAggregate.Entities
{
  public class Customer:AggregateRoot
  {
    public string Name { get; set; }
    public string SurName { get; set; }

    // Müşterinin kredileri
    public IReadOnlyCollection<Loan> Loans { get; set; }
    public IReadOnlyCollection<BankAccount> Accounts { get; set; }


    public Customer()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
