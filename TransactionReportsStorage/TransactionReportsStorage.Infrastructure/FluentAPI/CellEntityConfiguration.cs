using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Infrastructure.FluentAPI
{
    public class CellEntityConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder.HasMany<Record>(c => c.Records)
                   .WithOne(r => r.Cell);
        }
    }
}
