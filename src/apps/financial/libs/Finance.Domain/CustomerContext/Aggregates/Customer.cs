using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.CustomerContext.Aggregates
{
  // Gerçek Müşteri
  public class Customer:AggregateRoot
  {
    public string Name { get; set; }
    public string SurName { get; set; }
    public string IdentityNumber { get; set; }
    public string PhoneNumber { get; set; }


    public Customer()
    {

    }
  }
}
