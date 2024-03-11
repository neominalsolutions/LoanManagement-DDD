using Finance.Domain.LoanContext.Aggregates.LoanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.LoanAggregate
{
  public class LoanCustomerConfig : IEntityTypeConfiguration<LoanCustomer>
  {
    public void Configure(EntityTypeBuilder<LoanCustomer> builder)
    {
      builder.ToTable("LoanCustomer", "LoanContext");
      builder.HasMany(x => x.Loans);
      builder.OwnsOne(x => x.AnnualIncome).Property(x => x.Value).HasColumnName("AnnualIncome_Amount");
      builder.OwnsOne(x => x.AnnualIncome).Property(x => x.Currency).HasColumnName("AnnualIncome_Currency");
    }
  }
}
