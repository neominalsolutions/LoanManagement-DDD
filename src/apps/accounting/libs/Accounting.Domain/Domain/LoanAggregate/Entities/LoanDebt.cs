using Accounting.Domain.Domain.Shared.ValueObjects;
using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.CreditAggregate.Entities
{
    public class LoanDebt : Entity<string>
    {
        public LoanDebt()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Money Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }



    }
}
