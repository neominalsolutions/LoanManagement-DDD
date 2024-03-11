using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.BankingContext.Aggregates.AccountAggregate.Enumarations
{


    public class AccountTransactionType : Enumeration
    {
        public static AccountTransactionType IncomingTransfer = new(100, nameof(IncomingTransfer));
        public static AccountTransactionType OutComingTransfer = new(200, nameof(OutComingTransfer));



        public AccountTransactionType(int id, string name)
                : base(id, name)
        {
        }
    }

}
