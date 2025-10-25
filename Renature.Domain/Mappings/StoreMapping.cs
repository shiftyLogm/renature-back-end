using AutoMapper;
using Renature.Applications.Stores.Responses;
using Renature.Infra.Entities.Stores;

namespace Renature.Domain.Mappings;

public class StoreMapping : Profile
{
    public StoreMapping()
    {
        CreateMap<Store, StoreResponse>();
    }
}