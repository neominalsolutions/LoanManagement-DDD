using Accounting.Domain.Domain.CreditAggregate.Events;
using Accounting.Domain.Domain.Shared.ValueObjects;
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.CreditAggregate.Entities
{
  public class CustomerLoan : AggregateRoot
  {
    public CustomerLoan()
    {
      Id = Guid.NewGuid().ToString();
    }

    public string Name { get; set; } // Taşıt Kredisi
    public Money Limit { get; set; } // Ana Para
    public int Term { get; set; } // Kredi Vadesi
    public double BankRate { get; set; } // 
    public DateTime ExpiryDate { get; set; } // Vade Sonu Tarih 
    public string CustomerId { get; set; }

    private List<CustomerLoanDebt> _creditDebts = new List<CustomerLoanDebt>();
    public IReadOnlyCollection<CustomerLoanDebt> CreditDebts => _creditDebts;


    // Kredi kullanınca para yeni bir hesap açılışı yapılıp ana para müşterini hesabına yatacak
    public void ApplyForCredit()
    {

      // Kredi faizi hesaplanıp
      Money debt = new Money(Limit.Amount + Limit.Amount * (decimal)BankRate * Term, Limit.Currency);

      for (int i = 0; i < Term; i++)
      {
        _creditDebts.Add(new CustomerLoanDebt
        {
          DueDate = DateTime.Now.AddMonths(i + 1),
          Paid = false,
          Amount = new Money(debt.Amount / Term, debt.Currency)

        });
      }

      var @event = new LoanApproved(Id, CustomerId, Limit);
      AddDomainEvent(@event);


    }
  }
}
