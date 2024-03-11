using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Aggregates.LoanAggregate.Exceptions
{
  public class CreditScoreInsufficent:Exception
  {
    public CreditScoreInsufficent(string message = "Kredi puanınız yetersiz"):base(message)
    {

    }
  }
}
