using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Contributions.Interfaces;
using Renature.Applications.Contributions.Requests;
using Renature.Applications.Contributions.Responses;

namespace Renature.API.Controllers;

[ApiController]
[Route("api/contributions")]
[Authorize]
public class ContributionController : ControllerBase
{
    private readonly IContributionService _contributionService;

    public ContributionController(IContributionService contributionService)
    {
        _contributionService = contributionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ContributionRequest request)
    {
        var result = await _contributionService.CreateContribution(request, this);
        return result;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContributionResponse>> GetById([FromRoute] Guid id)
    {
        var contribution = await _contributionService.GetById(id, this);
        return contribution;
    }

    [HttpGet]
    public ActionResult<List<ContributionResponse>> GetAll([FromQuery] Guid? userId)
    {
        var contributions = _contributionService.GetAll(userId, this);
        return contributions;
    }
}