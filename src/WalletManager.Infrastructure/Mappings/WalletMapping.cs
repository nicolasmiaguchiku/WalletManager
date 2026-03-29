using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletManager.Domain.Enities;

namespace WalletManager.Infrastructure.Mappings
{
    public class WalletMapping : IEntityTypeConfiguration<WalletEntity>
    {
        public void Configure(EntityTypeBuilder<WalletEntity> builder)
        {
            builder.ToTable("Wallets");

            builder.Property(w => w.CustomerId)
                .IsRequired();

            builder.Property(w => w.Balance)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.HasIndex(w => w.CustomerId)
                .IsUnique()
                .HasDatabaseName("IX_Wallet_Customer");
        }
    }
}
