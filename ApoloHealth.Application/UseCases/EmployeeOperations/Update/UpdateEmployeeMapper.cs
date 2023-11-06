using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Update;

public sealed class UpdateEmployeeMapper : Profile
{
    public UpdateEmployeeMapper()
    {
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<Employee, UpdateEmployeeResponse>();
    }
}
