using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.GetAll;

public sealed class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, List<GetAllEmployeeResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public GetAllEmployeeHandler(IEmployeeRepository equipmentRepository, IMapper mapper)
    {
        _employeeRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllEmployeeResponse>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllEmployeeResponse>>(employees);
    }
}