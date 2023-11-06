using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Create
{
    public sealed class CreateCustomerMapper : Profile
    {
        public CreateCustomerMapper()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<Customer, CreateCustomerResponse>();
        }
    }
}
