using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core.Contracts
{
  public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey>, IWriteOnlyRepository<TEntity, TKey>
    where TEntity : IAggregateRoot
    where TKey : IComparable
  {
  }
}
