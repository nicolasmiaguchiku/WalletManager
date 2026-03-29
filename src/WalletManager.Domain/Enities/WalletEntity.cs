namespace WalletManager.Domain.Enities
{
    public class WalletEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
        public CustomerEntity Customer { get; set; } = default!;
        public ICollection<TransactionEntity> Transactions { get; set; } = [];

        public WalletEntity SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public WalletEntity SetCustomerId(Guid customerId)
        {
            CustomerId = customerId;
            return this;
        }

        public WalletEntity SetBalance(decimal balance)
        {
            Balance = balance;
            return this;
        }

        public WalletEntity SetCustomer(CustomerEntity customer)
        {
            Customer = customer;
            return this;
        }

        public WalletEntity SetTransactions(ICollection<TransactionEntity> transactions)
        {
            Transactions = transactions;
            return this;
        }

        public void SetTransaction(TransactionEntity transaction)
        {
            Transactions.Add(transaction);
        }

        public Builder ToBuilder()
        {
            return new Builder
            {
                Balance = Balance,
                CustomerId = CustomerId,
                Customer = Customer,
                Transactions = Transactions
            };
        }

        public class Builder
        {
            internal Guid Id { get; set; }
            internal Guid CustomerId { get; set; }
            internal decimal Balance { get; set; }
            internal CustomerEntity Customer { get; set; } = default!;
            internal ICollection<TransactionEntity> Transactions { get; set; } = [];

            public static Builder Create() => new();

            public Builder SetId(Guid id) { Id = id; return this; }
            public Builder SetCustomerId(Guid customerId) { CustomerId = customerId; return this; }
            public Builder SetBalance(decimal balance) { Balance = balance; return this; }
            public Builder SetCustomer(CustomerEntity customer) { Customer = customer; return this; }
            public Builder SetTransactions(ICollection<TransactionEntity> transactions) { Transactions = transactions; return this; }

            public WalletEntity Build()
            {
                return new WalletEntity
                {
                    Id = Id,
                    CustomerId = CustomerId,
                    Balance = Balance,
                    Customer = Customer,
                    Transactions = Transactions
                };
            }
        }
    }
}
