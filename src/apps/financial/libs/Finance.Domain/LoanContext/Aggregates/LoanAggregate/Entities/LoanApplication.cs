using Domain.Core.Contracts;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Enumerations;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Exceptions;
using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Services;
using Finance.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities
{
    // Kredi başvurusu
    public class LoanApplication : AggregateRoot
    {
        public Money LoanAmount { get; private set; } // İstenen Kredi Tutarı
        public DateTime CreatedAt { get; init; }
        public string LoadCustomerId { get; private set; } // Kredi başvurusu yapan müşteri

        public Money AnnualIncome { get; private set; } // Yıllık Kazanç

        public LoanApplicationType LoanType { get; private set; } // Başvuru Tipi

        public bool Approved { get; private set; }

        public int Term { get; private set; } // Kaç ay vadeli

        public double BankRate { get; private set; } // Banka Faiz oranı


        public LoanApplication()
        {

        }
        public LoanApplication(string customerId, Money loanAmount, Money annualIncome, LoanApplicationType loanType, int term)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            LoadCustomerId = customerId;
            LoanAmount = loanAmount;
            AnnualIncome = annualIncome;
            LoanType = loanType;
            Term = term;
            BankRate = CalculateBankRate(term);
        }


        private double CalculateBankRate(int term)
        {
            if (term <= 12)
            {
                return 1.99;
            }
            else if (term > 12 && term <= 24)
            {
                return 2.29;
            }
            else
            {
                return 3.35;
            }
        }

        /// <summary>
        /// Burada Loan sınıfı içerisinde Kredi notu hesaplayamadığımızdan CreditScoreService domain servisinden yararlandık. Method Injection Yaptık.
        /// </summary>
        /// <param name="creditScoreService"></param>
        /// <exception cref="CreditScoreInsufficent"></exception>
        public void CheckApproval(CreditScoreService creditScoreService)
        {
            var approved = creditScoreService.IsApproved(this);

            if (!approved)
            {
                throw new CreditScoreInsufficent();
            }
            else
            {
                // Kredi onaylanınca direk kredi kullanımı yapılsın
                // farklı bir aggregate root'a gideceğimizden loan approved eventi fırlatacağız.
                var @event = new LoanApproved(Id, LoadCustomerId, LoanAmount, Term, BankRate);
                AddDomainEvent(@event);
            }

        }


    }
}
