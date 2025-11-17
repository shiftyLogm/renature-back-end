using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Contributions.Requests;
using Renature.Applications.Contributions.Responses;
using Renature.Applications.Stores.Responses;

namespace Renature.Applications.Contributions.Interfaces;

public interface IContributionService
{
    Task<ActionResult<ContributionResponse>> GetById(Guid id, ControllerBase controller);
    ActionResult<List<ContributionResponse>> GetAll(Guid? userId, ControllerBase controller);
    Task<ActionResult> CreateContribution(ContributionRequest request, ControllerBase controller);
}