using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations
{
    public class MoneyTransferChannel : Enumeration
    {

        public static MoneyTransferChannel Bank = new(1, nameof(Bank));
        public static MoneyTransferChannel Online = new(2, nameof(Online));
        public static MoneyTransferChannel ATM = new(3, nameof(ATM));
        public static MoneyTransferChannel Loan = new(4, nameof(Loan));

        public MoneyTransferChannel(int id, string name)
            : base(id, name)
        {
        }

    }
}
