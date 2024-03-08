using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Domain.LoanAggregate.Exceptions
{
  public class PayableAmountNotValid:Exception
  {
    public PayableAmountNotValid(string message = "Borç tutarının altında ödeme yapılamaz") :base(message)
    {

    }
  }
}
