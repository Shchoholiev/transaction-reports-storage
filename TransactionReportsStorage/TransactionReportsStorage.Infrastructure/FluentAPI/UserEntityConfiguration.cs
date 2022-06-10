using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransactionReportsStorage.Core.Entities;

namespace TransactionReportsStorage.Infrastructure.FluentAPI
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany<Record>(u => u.Records)
                   .WithOne(r => r.User);
        }
    }
}
