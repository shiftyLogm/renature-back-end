using Microsoft.AspNetCore.Mvc;
using Renature.Infra.Entities.Stores;
using Renature.Infra.Entities.Stores.Interfaces;

namespace Renature.API.Controllers;

[Route("api/stores")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;

    // Construtor tradicional
    public StoreController(IStoreRepository repository)
    {
        _storeRepository = repository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Store>> GetById(
        [FromRoute] Guid id)
    {
        var store = await _storeRepository.GetById(id);

        if (store == null)
        {
            return NotFound();
        }

        return Ok(store);
    }
}