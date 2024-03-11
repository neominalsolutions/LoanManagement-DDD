using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.LoanAggregate
{
    public class LoanConfig : IEntityTypeConfiguration<Loan>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Loan> builder)
    {
      builder.ToTable("Loan", "LoanContext");
      builder.HasMany(x => x.Debts);
      // Value Object Mapping yaptık
      builder.OwnsOne(x => x.PrincipalAmount).Property(x => x.Value).HasColumnName("Principle_Amount");
      builder.OwnsOne(x => x.PrincipalAmount).Property(x => x.Currency).HasColumnName("Principle_Currency");

      builder.OwnsOne(x => x.RemainingAmount).Property(x => x.Value).HasColumnName("Remaning_Amount");

      builder.OwnsOne(x => x.RemainingAmount).Property(x => x.Currency).HasColumnName("Remaning_Currency");

    }
  }
}
