using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Delete;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, DeleteEmployeeResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public DeleteEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<DeleteEmployeeResponse> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.Get(request.Id, cancellationToken);

        if (employee == null) { return default; }

        _employeeRepository.Delete(employee);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteEmployeeResponse>(employee);
    }
}
