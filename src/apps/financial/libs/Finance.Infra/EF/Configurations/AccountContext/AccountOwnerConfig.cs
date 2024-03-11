using Finance.Domain.AccountContext.Aggregates.OwnerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.AccountContext
{
  public class AccountOwnerConfig : IEntityTypeConfiguration<AccountOwner>
  {
    public void Configure(EntityTypeBuilder<AccountOwner> builder)
    {
      builder.ToTable("AccountOwner", "AccountContext");
      builder.HasMany(x => x.Accounts);
      builder.OwnsOne(x => x.AccountType).Property(x => x.Id).HasColumnName("Account_Type_Code");
    }
  }
}
