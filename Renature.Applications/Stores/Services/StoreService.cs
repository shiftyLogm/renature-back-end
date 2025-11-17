using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Stores.Interfaces;
using Renature.Applications.Stores.Responses;
using Renature.Infra.Entities.Stores.Interfaces;

namespace Renature.Applications.Stores.Services;

public class StoreService(IStoreRepository storeRepository, IMapper mapper) : IStoreService
{
    public async Task<ActionResult<StoreResponse>> GetById(Guid id, ControllerBase controller)
    {
        var store = await storeRepository.GetById(id);

        if (store is null) return controller.NotFound("Store not found");
        
        return controller.Ok(mapper.Map<StoreResponse>(store));
    }

    public ActionResult<List<StoreResponse>> GetAll(ControllerBase controller)
    {
        var stores = storeRepository.GetAll();

        if (!stores.Any()) return controller.NoContent();
        
        var result = stores.Select(s => mapper.Map<StoreResponse>(s)).ToList();

        return controller.Ok(result);
    }
}