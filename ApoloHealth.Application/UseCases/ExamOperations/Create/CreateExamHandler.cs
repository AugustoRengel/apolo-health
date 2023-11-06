using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create;

internal class CreateExamHandler : IRequestHandler<CreateExamRequest, CreateExamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamRepository _examRepository;
    private readonly IMapper _mapper;
    public CreateExamHandler(IUnitOfWork unitOfWork, IExamRepository examRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _examRepository = examRepository;
        _mapper = mapper;
    }
    public async Task<CreateExamResponse> Handle(CreateExamRequest request, CancellationToken cancellationToken)
    {
        var exam = _mapper.Map<Exam>(request);
        _examRepository.Create(exam);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateExamResponse>(exam);
    }
}
