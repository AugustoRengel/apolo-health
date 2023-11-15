using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AddressOperations.Update;

public sealed class UpdateAddressMapper : Profile
{
    public UpdateAddressMapper()
    {
        CreateMap<UpdateAddressRequest, Address>();
        CreateMap<Address, UpdateAddressResponse>();
    }
}
