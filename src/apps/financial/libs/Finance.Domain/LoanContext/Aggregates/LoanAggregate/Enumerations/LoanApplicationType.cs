﻿using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.LoanContext.Aggregates.LoanAggregate.Enumerations
{
    public class LoanApplicationType : Enumeration
    {
        public static LoanApplicationType PersonalLoan = new(100, nameof(PersonalLoan));
        public static LoanApplicationType VechicleLoan = new(200, nameof(VechicleLoan));

        public LoanApplicationType(int id, string name)
            : base(id, name)
        {
        }
    }
}
