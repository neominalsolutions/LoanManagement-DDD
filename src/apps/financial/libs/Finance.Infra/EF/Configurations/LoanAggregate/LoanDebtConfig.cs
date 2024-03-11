using Finance.Domain.Aggregates.LoanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.LoanAggregate
{
  public class LoanDebtConfig : IEntityTypeConfiguration<LoanDebt>
  {
    public void Configure(EntityTypeBuilder<LoanDebt> builder)
    {
      builder.OwnsOne(x => x.Amount).Property(x => x.Value).HasColumnName("Debt_Amount");
      builder.OwnsOne(x => x.Amount).Property(x => x.Currency).HasColumnName("Debt_Currency");
    }
  }
}
