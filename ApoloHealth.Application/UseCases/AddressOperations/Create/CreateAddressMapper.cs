using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AddressOperations.Create
{
    public sealed class CreateAddressMapper : Profile
    {
        public CreateAddressMapper()
        {
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<Address, CreateAddressResponse>();
        }
    }
}
