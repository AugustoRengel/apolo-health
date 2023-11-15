using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AddressOperations.GetAll;

public sealed class GetAllAddressMapper : Profile
{
    public GetAllAddressMapper()
    {
        CreateMap<Address, GetAllAddressResponse>();
    }

}
