using WalletManager.Domain.Enum;

namespace WalletManager.Domain.Enities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = default!;
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public WalletEntity Wallet { get; set; } = default!;

        public TransactionEntity SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public TransactionEntity SetWalletId(Guid walletId)
        {
            WalletId = walletId;
            return this;
        }

        public TransactionEntity SetAmount(decimal amount)
        {
            Amount = amount;
            return this;
        }

        public TransactionEntity SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public TransactionEntity SetType(TransactionType type)
        {
            Type = type;
            return this;
        }

        public TransactionEntity SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
            return this;
        }

        public TransactionEntity SetWallet(WalletEntity wallet)
        {
            Wallet = wallet;
            return this;
        }

        public Builder ToBuilder()
        {
            return new Builder
            {
                Id = Id,
                WalletId = WalletId,
                Amount = Amount,
                Description = Description,
                Type = Type,
                CreatedAt = CreatedAt,
                Wallet = Wallet
            };
        }

        public class Builder
        {
            internal Guid Id { get; set; }
            internal Guid WalletId { get; set; }
            internal decimal Amount { get; set; }
            internal string Description { get; set; } = default!;
            internal TransactionType Type { get; set; }
            internal DateTime CreatedAt { get; set; }
            internal WalletEntity Wallet { get; set; } = default!;

            public static Builder Create() => new();

            public Builder SetId(Guid id) { Id = id; return this; }
            public Builder SetWalletId(Guid walletId) { WalletId = walletId; return this; }
            public Builder SetAmount(decimal amount) { Amount = amount; return this; }
            public Builder SetDescription(string description) { Description = description; return this; }
            public Builder SetType(TransactionType type) { Type = type; return this; }
            public Builder SetCreatedAt(DateTime createdAt) { CreatedAt = createdAt; return this; }
            public Builder SetWallet(WalletEntity wallet) { Wallet = wallet; return this; }

            public TransactionEntity Build()
            {
                return new TransactionEntity
                {
                    Id = Id,
                    WalletId = WalletId,
                    Amount = Amount,
                    Description = Description,
                    Type = Type,
                    CreatedAt = CreatedAt,
                    Wallet = Wallet
                };
            }
        }
    }
}