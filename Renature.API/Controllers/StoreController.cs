using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Stores.Interfaces;
using Renature.Applications.Stores.Responses;
using Renature.Infra.Entities.Stores;
using Renature.Infra.Entities.Stores.Interfaces;

namespace Renature.API.Controllers;

[Route("api/stores")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StoreResponse>> GetById([FromRoute] Guid id)
    {
        var store = await _storeService.GetById(id, this);
        return store;
    }

    [HttpGet]
    public ActionResult<List<StoreResponse>> GetAll()
    {
        var stores = _storeService.GetAll(this);
        return stores;
    }
}