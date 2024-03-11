using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.LoanAggregate.Exceptions
{
  public class PayableAmountNotValid:Exception
  {
    public PayableAmountNotValid(string message = "Borç tutarının altında ödeme yapılamaz") :base(message)
    {

    }
  }
}
