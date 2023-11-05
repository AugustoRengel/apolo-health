using ApoloHealth.Application.UseCases.ExamOperations.Delete;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public class DeleteExamHandler : IRequestHandler<DeleteExamRequest, DeleteExamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamRepository _examRepository;
    private readonly IMapper _mapper;
    public DeleteExamHandler(IUnitOfWork unitOfWork, IExamRepository examRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _examRepository = examRepository;
        _mapper = mapper;
    }
    public async Task<DeleteExamResponse> Handle(DeleteExamRequest request, CancellationToken cancellationToken)
    {
        var exam = await _examRepository.Get(request.Id, cancellationToken);

        if (exam == null) { return default; }

        _examRepository.Delete(exam);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteExamResponse>(exam);
    }
}
