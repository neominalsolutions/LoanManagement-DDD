using Finance.Domain.Aggregates.CustomerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infra.EF.Configurations.CustomerAggregate
{
  public class CustomerConfig : IEntityTypeConfiguration<Customer>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
    {
      builder.HasMany(x => x.Loans);
      builder.HasMany(x => x.Accounts);
    }
  }
}
