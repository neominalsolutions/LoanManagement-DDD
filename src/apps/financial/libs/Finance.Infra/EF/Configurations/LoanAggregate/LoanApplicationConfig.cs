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
    public class LoanApplicationConfig : IEntityTypeConfiguration<LoanApplication>
  {
    public void Configure(EntityTypeBuilder<LoanApplication> builder)
    {
      builder.ToTable("LoanApplication", "LoanContext");
      // Enumarationları ve ValueObjectleri doğru bir şekilde mapliyoruz
      builder.OwnsOne(x => x.LoanType).Property(x => x.Id).HasColumnName("Loan_Type");
      builder.OwnsOne(x => x.AnnualIncome).Property(x => x.Value).HasColumnName("AnnoulIncome_Amount");
      builder.OwnsOne(x => x.AnnualIncome).Property(x => x.Currency).HasColumnName("AnnoulIncome_Currency");

      builder.OwnsOne(x => x.LoanAmount).Property(x => x.Value).HasColumnName("Loan_Amount");
      builder.OwnsOne(x => x.LoanAmount).Property(x => x.Currency).HasColumnName("Loan_Currency");


      builder.OwnsOne(x => x.LoanType).Property(x => x.Id).HasColumnName("Loan_Type");


    }
  }
}
