using WalletManager.Domain.Enities;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Infrastructure.Context;

namespace WalletManager.Infrastructure.Repositories;

public class WalletRepository(DataContext dataContext) :
    BaseRepository<WalletEntity>(dataContext), IWalletRepository;