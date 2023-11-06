using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Update;

public sealed class UpdateCustomerMapper : Profile
{
    public UpdateCustomerMapper()
    {
        CreateMap<UpdateCustomerRequest, Customer>();
        CreateMap<Customer, UpdateCustomerResponse>();
    }
}
