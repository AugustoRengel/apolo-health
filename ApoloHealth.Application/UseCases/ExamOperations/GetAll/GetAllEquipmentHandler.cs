using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll;

public sealed class GetAllExamHandler : IRequestHandler<GetAllExamRequest, List<GetAllExamResponse>>
{
    private readonly IExamRepository _examRepository;
    private readonly IMapper _mapper;
    public GetAllExamHandler(IExamRepository equipmentRepository, IMapper mapper)
    {
        _examRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllExamResponse>> Handle(GetAllExamRequest request, CancellationToken cancellationToken)
    {
        var exams = await _examRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllExamResponse>>(exams);
    }
}