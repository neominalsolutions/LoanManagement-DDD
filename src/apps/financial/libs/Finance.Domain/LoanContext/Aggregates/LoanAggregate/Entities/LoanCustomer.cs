using Domain.Core.Contracts;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities
{
  public class LoanCustomer:AggregateRoot
  {

    // Müşterinin kredileri
    public IReadOnlyList<Loan> Loans { get; set; }

    public Money AnnualIncome { get; private set; } // Müşteri Yıllık Geliri

    public int CreditScore { get; private set; } // Kredi Puanı

    public LoanCustomer()
    {

    }

    public LoanCustomer(string customerId) // CustomerId ile LoanCustomerId birebir eşleşiyor aynı id üzerinden çalışır.
    {
      Id = customerId; 
    }



  }
}
