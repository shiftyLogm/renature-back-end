using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Stores.Responses;

namespace Renature.Applications.Stores.Interfaces;

public interface IStoreService
{
    Task<ActionResult<StoreResponse>> GetById(Guid id, ControllerBase controller);
    ActionResult<List<StoreResponse>> GetAll(ControllerBase controller);
}