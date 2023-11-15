using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System.Reflection;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Update;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, UpdateEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public UpdateEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeRequest command, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.Get(command.Id, cancellationToken);

        if (employee == null) { return default; }
        var employeeUpdate = _mapper.Map<Employee>(command);

        if (employeeUpdate.Role != null) { employee.Role = employeeUpdate.Role; }
        if (employeeUpdate.Wage != null) { employee.Wage = employeeUpdate.Wage; }
        if (!string.IsNullOrEmpty(employeeUpdate.Name)) { employee.Name = employeeUpdate.Name; }
        if (!string.IsNullOrEmpty(employeeUpdate.CPF)) { employee.CPF = employeeUpdate.CPF; }
        if (employeeUpdate.BirthDate != null) { employee.BirthDate = employeeUpdate.BirthDate; }
        if (!string.IsNullOrEmpty(employeeUpdate.Email)) { employee.Email = employeeUpdate.Email; }
        if (!string.IsNullOrEmpty(employeeUpdate.Phone)) { employee.Phone = employeeUpdate.Phone; }
        if (employeeUpdate.Gender != null) { employee.Gender = employeeUpdate.Gender; }
        if (!string.IsNullOrEmpty(employeeUpdate.Nationality)) { employee.Nationality = employeeUpdate.Nationality; }
        if (employeeUpdate.MaritalStatus != null) { employee.MaritalStatus = employeeUpdate.MaritalStatus; }

        _employeeRepository.Update(employee);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateEmployeeResponse>(employee);
    }
}
