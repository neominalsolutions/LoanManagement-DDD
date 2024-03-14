using Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Core.Contracts
{
  public interface IReadOnlyRepository<TRoot, TKey>
   where TRoot : IAggregateRoot
   where TKey : IComparable
  {

    TRoot FindById(TKey Id);
    IEnumerable<TRoot> Find();
    IEnumerable<TRoot> Find(Expression<Func<TRoot, bool>> lamda);
    IQueryable<TRoot> Query(Expression<Func<TRoot, bool>> lamda);



  }
}
