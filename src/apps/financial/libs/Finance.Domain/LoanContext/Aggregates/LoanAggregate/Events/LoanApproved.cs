using Finance.Domain.Shared.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events
{
    public class LoanApproved : INotification
    {
        public LoanApproved(string loanId, string customerId, Money loanAmount, int term, double bankRate)
        {
            LoanApplicationId = loanId;
            CustomerId = customerId;
            LoanAmount = loanAmount;
        }

        public string LoanApplicationId { get; init; }
        public string CustomerId { get; init; }
        public Money LoanAmount { get; init; } // Toplam Kredi Limiti

        public int Term { get; init; }

        public double BankRate { get; init; }


    }

}
