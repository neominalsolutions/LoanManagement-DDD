using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.AccountAggregate.Enumarations
{


    public class BankAccountTransactionType : Enumeration
    {
        public static BankAccountTransactionType IncomingTransfer = new(100, nameof(IncomingTransfer));
        public static BankAccountTransactionType OutComingTransfer = new(200, nameof(OutComingTransfer));



    public BankAccountTransactionType(int id, string name)
            : base(id, name)
        {
        }
    }

}
