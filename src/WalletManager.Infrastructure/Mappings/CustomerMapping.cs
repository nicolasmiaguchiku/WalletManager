using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WalletManager.Domain.Enities;

namespace WalletManager.Infrastructure.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customers");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.PasswordHash)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.HasIndex(c => c.Email)
                .HasDatabaseName("IX_Customer_Email");

            builder.HasOne(c => c.Wallet)
                .WithOne(w => w.Customer)
                .HasForeignKey<WalletEntity>(w => w.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
