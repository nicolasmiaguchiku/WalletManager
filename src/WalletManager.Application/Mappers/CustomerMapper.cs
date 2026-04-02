using WalletManager.Application.Requests;
using WalletManager.Domain.Enities;

namespace WalletManager.Application.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerEntity ToEntity(this CreateAccountCustomerRequest request, string passwordHash)
        {
            return CustomerEntity.Builder.Create()
                .SetId(Guid.NewGuid())
                .SetName(request.Name)
                .SetEmail(request.Email)
                .SetPhoneNumber(request.PhoneNumber)
                .SetPasswordHash(passwordHash)
                .Build();
        }
    }
}
