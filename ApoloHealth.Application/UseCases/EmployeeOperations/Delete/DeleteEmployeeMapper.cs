using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Delete;

public sealed class DeleteEmployeeMapper : Profile
{
    public DeleteEmployeeMapper()
    {
        CreateMap<DeleteEmployeeRequest, Employee>();
        CreateMap<Employee, DeleteEmployeeResponse>();
    }
}
