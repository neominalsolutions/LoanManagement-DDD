using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.AccountAggregate.Enumarations
{


    public class CustomerAccountTransactionType : Enumeration
    {
        public static CustomerAccountTransactionType Deposit = new(100, nameof(Deposit));
        public static CustomerAccountTransactionType Withdraw = new(200, nameof(Withdraw));

        public CustomerAccountTransactionType(int id, string name)
            : base(id, name)
        {
        }
    }

}
