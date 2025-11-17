using AutoMapper;
using Renature.Applications.Contributions.Requests;
using Renature.Applications.Contributions.Responses;
using Renature.Infra.Entities.Contributions;

namespace Renature.Domain.Mappings;

public class ContributionMapping : Profile
{
    public ContributionMapping()
    {
        CreateMap<ContributionRequest, Contribution>();
        CreateMap<Contribution, ContributionResponse>();
    }
}