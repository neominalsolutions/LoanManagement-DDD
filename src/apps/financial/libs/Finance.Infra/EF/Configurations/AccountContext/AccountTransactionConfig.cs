﻿using Finance.Domain.BankingContext.Aggregates.AccountAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.BankAccountAggregate
{
    public class AccountTransactionConfig : IEntityTypeConfiguration<AccountTransaction>
  {
    public void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {
      builder.ToTable("AccountTransaction", "AccountContext");

      builder.OwnsOne(x => x.Money).Property(x => x.Value).HasColumnName("Money_Amount");
      builder.OwnsOne(x => x.Money).Property(x => x.Currency).HasColumnName("Money_Currency");

      builder.OwnsOne(x => x.Type).Property(x => x.Id).HasColumnName("Transaction_Code");

      builder.OwnsOne(x => x.TransferChannel).Property(x => x.Id).HasColumnName("Transafer_Channel_Code");


    }
  }
}
