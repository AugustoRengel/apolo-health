using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public class UpdateExamHandler : IRequestHandler<UpdateExamRequest, UpdateExamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExamRepository _examRepository;
    private readonly IMapper _mapper;
    public UpdateExamHandler(IUnitOfWork unitOfWork, IExamRepository examRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _examRepository = examRepository;
        _mapper = mapper;
    }
    public async Task<UpdateExamResponse> Handle(UpdateExamRequest command, CancellationToken cancellationToken)
    {
        var exam = await _examRepository.Get(command.Id, cancellationToken);

        if (exam == null) { return default; }
        var examUpdate = _mapper.Map<Exam>(command);

        if (!string.IsNullOrEmpty(examUpdate.Title)) { exam.Title = examUpdate.Title; }
        if (!string.IsNullOrEmpty(examUpdate.Description)) { exam.Description = examUpdate.Description; }
        if (examUpdate.DurationInMinutes != null) { exam.DurationInMinutes = examUpdate.DurationInMinutes; }
        if (examUpdate.RequiredEmployeeRole != null) { exam.RequiredEmployeeRole = examUpdate.RequiredEmployeeRole; }
        if (examUpdate.RequiredEquipmentType != null) { exam.RequiredEquipmentType = examUpdate.RequiredEquipmentType; }

        _examRepository.Update(exam);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateExamResponse>(exam);
    }
}
