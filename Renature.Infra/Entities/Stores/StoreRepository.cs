using Renature.Infra.Abstractions;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Stores.Interfaces;

namespace Renature.Infra.Entities.Stores;

public class StoreRepository(RenatureDbContext context) : Repository<Store>(context), IStoreRepository;