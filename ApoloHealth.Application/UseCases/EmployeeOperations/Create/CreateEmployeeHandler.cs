using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Create;

internal class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public CreateEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        _employeeRepository.Create(employee);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateEmployeeResponse>(employee);
    }
}
