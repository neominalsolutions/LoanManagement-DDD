using Domain.Core.Contracts;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Exceptions;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities
{
    public class Loan : AggregateRoot
    {
        public Loan()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; } // Taşıt Kredisi
        public Money PrincipalAmount { get; set; } // Ana Para

        public Money RemainingAmount { get; set; } // Kalan Borç
        public int Term { get; init; } // Kredi Vadesi
        public double BankRate { get; init; } // 
        public DateTime ExpiryDate { get; init; } // Vade Sonu Tarih 
        public string LoanCustomerId { get; init; }

        public string LoanAccountNumber { get; private set; } // Kredinin Kullanıldığı hesap Numarası


        private List<LoanDebt> _debts = new List<LoanDebt>();
        public IReadOnlyCollection<LoanDebt> Debts => _debts;


        public bool Closed { get; private set; } // Kredi Kapandı mı?


        public Loan(string loanApplicationId, Money principalAmount, string loadCustomerId, int term, double bankRate)
        {
            Id = loanApplicationId;
            PrincipalAmount = principalAmount;
            LoanCustomerId = loadCustomerId;
            ExpiryDate = DateTime.Now.AddMonths(term);
            RemainingAmount = CalculateLoanInterest();
            BankRate = bankRate;
        }

        // Kredi faizi hesapla
        private Money CalculateLoanInterest()
        {
            return new Money(PrincipalAmount.Value + PrincipalAmount.Value * (decimal)BankRate * Term, PrincipalAmount.Currency);
        }


        /// <summary>
        /// Kredi Onayı
        /// </summary>
        public void ApproveLoan()
        {

            for (int i = 0; i < Term; i++)
            {
                _debts.Add(new LoanDebt
                {
                    DueDate = DateTime.Now.AddMonths(i + 1),
                    Paid = false,
                    Amount = new Money(RemainingAmount.Value / Term, RemainingAmount.Currency)

                });

            }

            var @event = new LoanSubmitted(this);
            AddDomainEvent(@event);

        }

        /// <summary>
        /// Kredi Ödemesi
        /// </summary>
        /// <param name="PayableAmount"></param>
        /// <exception cref="PayableAmountNotValid"></exception>
        public void MakePayment(Money PayableAmount)
        {

            var loanDebt = _debts.OrderBy(x => x.PaidDate).FirstOrDefault(x => x.Paid != false);

            if (loanDebt is not null)
            {

                if (loanDebt.Amount == PayableAmount)
                {
                    loanDebt.Amount -= PayableAmount;
                    loanDebt.PaidDate = DateTime.Now;
                    loanDebt.Paid = true;
                    // Borç tutarı toplam ödenecek olan tutardan düştü.
                    RemainingAmount -= PayableAmount;

                    if (RemainingAmount.Value == 0)
                    {
                        Closed = true;
                    }
                }
                else
                {
                    throw new PayableAmountNotValid();
                }



            }

        }

        public void SetLoanAccountNumber(string accountNumber)
        {
            LoanAccountNumber = accountNumber;
        }
    }
}
