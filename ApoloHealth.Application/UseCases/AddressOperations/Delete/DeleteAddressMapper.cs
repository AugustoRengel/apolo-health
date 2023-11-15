using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AddressOperations.Delete;

public sealed class DeleteAddressMapper : Profile
{
    public DeleteAddressMapper()
    {
        CreateMap<DeleteAddressRequest, Address>();
        CreateMap<Address, DeleteAddressResponse>();
    }
}
