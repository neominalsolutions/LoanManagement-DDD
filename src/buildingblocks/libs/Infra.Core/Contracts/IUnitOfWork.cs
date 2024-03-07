using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core.Contracts
{
  public interface IUnitOfWork
  {
    void AutoSave(); // Transaction uygula
    void Save();
  }
}
