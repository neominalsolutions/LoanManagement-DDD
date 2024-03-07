using Accounting.Domain.Domain.CreditAggregate.Entities;
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.CustomerAggregate.Entities
{
  public class Customer:AggregateRoot
  {
    public string Name { get; set; }
    public string SurName { get; set; }

    // Müşterinin kredileri
    public IReadOnlyCollection<CustomerLoan> Loans { get; set; }

    public Customer()
    {
      Id = Guid.NewGuid().ToString();
    }
  }
}
