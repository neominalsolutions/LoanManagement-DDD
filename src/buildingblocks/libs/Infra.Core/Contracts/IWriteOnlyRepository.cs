using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core.Contracts
{
  public interface IWriteOnlyRepository<TEntity, TKey>
     where TEntity : IAggregateRoot
     where TKey : IComparable
  {
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TKey Id);
  }
}
