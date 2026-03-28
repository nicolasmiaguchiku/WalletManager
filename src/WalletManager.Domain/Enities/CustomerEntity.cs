namespace WalletManager.Domain.Enities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;

        public CustomerEntity SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public CustomerEntity SetName(string name)
        {
            Name = name;
            return this;
        }

        public CustomerEntity SetEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerEntity SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public CustomerEntity SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            return this;
        }

        public Builder ToBuilder()
        {
            return new Builder
            {
                Name = Name,
                Email = Email,
                PhoneNumber = PhoneNumber,
                PassdwordHash = PasswordHash
            };
        }

        public class Builder
        {
            internal Guid Id { get; set; }
            internal string Name { get; set; } = default!;
            internal string Email { get; set; } = default!;
            internal string PhoneNumber { get; set; } = default!;
            internal string PassdwordHash { get; set; } = default!;

            public static Builder Create() => new();

            public Builder SetId(Guid id) { Id = id; return this; }
            public Builder SetName(string name) { Name = name; return this; }
            public Builder SetEmail(string email) { Email = email; return this; }
            public Builder SetPhoneNumber(string phoneNumber) { PhoneNumber = phoneNumber; return this; }
            public Builder SetPassdwordHash(string passdwordHash) { PassdwordHash = passdwordHash; return this; }

            public CustomerEntity Build()
            {
                return new CustomerEntity
                {
                    Id = Id,
                    Name = Name,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    PasswordHash = PassdwordHash
                };
            }
        }
    }
}