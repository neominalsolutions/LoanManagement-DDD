using Domain.Core.Contracts;
using Infra.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Repositories
{
  public abstract class EFRepository<TContext, TEntity, TKey> : ICrudRepository<TEntity, TKey>
     where TEntity : AggregateRoot
     where TKey : IComparable
     where TContext : DbContext
  {
    protected readonly TContext db;
    protected readonly DbSet<TEntity> table;


    public EFRepository(TContext db)
    {
      this.db = db;
      this.table = db.Set<TEntity>(); // tabloyu db deki entity bağladık.
    }



    public virtual void Create(TEntity entity)
    {
      this.table.Add(entity);
    }

    public virtual void Delete(TKey Id)
    {
      var entity = FindById(Id);
      this.table.Remove(entity);
    }

    public virtual IEnumerable<TEntity> Find()
    {
      return this.table.ToList();
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> lamda)
    {
      return this.table.Where(lamda).ToList();
    }

    public virtual TEntity FindById(TKey Id)
    {
      var entity = table.Find(Id);

      if (entity is null)
      {
        throw new Exception("Entity Not Found");
      }

      return entity;
    }

    public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> lamda)
    {
      return this.table.Where(lamda);
    }

    public virtual void Update(TEntity entity)
    {
      this.table.Update(entity);
    }
  }
}
