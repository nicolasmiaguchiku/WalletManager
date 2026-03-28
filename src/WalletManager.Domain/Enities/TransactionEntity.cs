using WalletManager.Domain.Enum;

namespace WalletManager.Domain.Enities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public WalletEntity Wallet { get; set; } = default!;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public TransactionEntity SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public TransactionEntity SetWallet(WalletEntity wallet)
        {
            Wallet = wallet;
            return this;
        }

        public TransactionEntity SetAmount(decimal amount)
        {
            Amount = amount;
            return this;
        }

        public TransactionEntity SetType(TransactionType type)
        {
            Type = type;
            return this;
        }

        public TransactionEntity SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public TransactionEntity SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
            return this;
        }

        public Builder ToBuilder()
        {
            return new Builder
            {
                Wallet = Wallet,
                Amount = Amount,
                Type = Type,
                Description = Description,
                CreatedAt = CreatedAt
            };
        }

        public class Builder
        {
            internal Guid Id { get; set; }
            internal WalletEntity Wallet { get; set; } = default!;
            internal decimal Amount { get; set; }
            internal TransactionType Type { get; set; }
            internal string Description { get; set; } = default!;
            internal DateTime CreatedAt { get; set; }

            public static Builder Create() => new();

            public Builder SetId(Guid id) { Id = id; return this; }
            public Builder SetWallet(WalletEntity wallet) { Wallet = wallet; return this; }
            public Builder SetAmount(decimal amount) { Amount = amount; return this; }
            public Builder SetType(TransactionType type) { Type = type; return this; }
            public Builder SetDescription(string description) { Description = description; return this; }
            public Builder SetCreatedAt(DateTime createdAt) { CreatedAt = createdAt; return this; }

            public TransactionEntity Build()
            {
                return new TransactionEntity
                {
                    Id = Id,
                    Wallet = Wallet,
                    Amount = Amount,
                    Type = Type,
                    Description = Description,
                    CreatedAt = CreatedAt
                };
            }
        }
    }
}