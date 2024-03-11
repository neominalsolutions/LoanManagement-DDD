using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Events
{
    // Kredilendirildi.
    public class LoanSubmitted : INotification
    {

        public Loan Loan { get; init; }
        public LoanSubmitted(Loan loan)
        {
            Loan = loan;
        }


    }
}
