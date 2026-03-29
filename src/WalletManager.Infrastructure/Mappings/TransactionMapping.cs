using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletManager.Domain.Enities;

namespace WalletManager.Infrastructure.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transactions");

            builder.Property(t => t.Amount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(t => t.Type)
                .HasColumnType("varchar(20)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(t => t.WalletId)
                .HasDatabaseName("IX_Transaction_WalletId");
        }
    }
}
