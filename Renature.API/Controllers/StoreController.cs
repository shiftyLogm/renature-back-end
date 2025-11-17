using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Stores.Interfaces;
using Renature.Applications.Stores.Responses;

namespace Renature.API.Controllers;

[Route("api/stores")]
[ApiController]
[Authorize]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet("{id:guid}")]
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