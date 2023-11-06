using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Create
{
    public sealed class CreateEmployeeMapper : Profile
    {
        public CreateEmployeeMapper()
        {
            CreateMap<CreateEmployeeRequest, Employee>();
            CreateMap<Employee, CreateEmployeeResponse>();
        }
    }
}
