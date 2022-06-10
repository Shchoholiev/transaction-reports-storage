using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Infrastructure.FluentAPI
{
    public class RecordEntityConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasOne<User>(r => r.User)
                   .WithMany(u => u.Records);

            builder.HasOne<Cell>(r => r.Cell)
                   .WithMany(c => c.Records);
        }
    }
}
