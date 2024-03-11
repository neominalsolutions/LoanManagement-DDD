using Finance.Domain.Aggregates.AccountAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.BankAccountAggregate
{
  public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
  {
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
      builder.HasMany(x => x.Transactions);
      builder.OwnsOne(x => x.Balance).Property(x => x.Value).HasColumnName("Balance_Amount");
      builder.OwnsOne(x => x.Balance).Property(x => x.Currency).HasColumnName("Balance_Currency");

    }
  }
}
