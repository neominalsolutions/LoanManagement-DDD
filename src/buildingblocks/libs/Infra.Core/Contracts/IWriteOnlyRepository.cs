using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core.Contracts
{
  public interface IWriteOnlyRepository<TRoot, TKey>
     where TRoot : IAggregateRoot
     where TKey : IComparable
  {
    void Create(TRoot entity);
    void Update(TRoot entity);
    void Delete(TKey Id);
  }
}
