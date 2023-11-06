using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Delete;

public sealed class DeleteCustomerMapper : Profile
{
    public DeleteCustomerMapper()
    {
        CreateMap<DeleteCustomerRequest, Customer>();
        CreateMap<Customer, DeleteCustomerResponse>();
    }
}
