using ApoloHealth.Application.UseCases.ExamOperations.Create;
using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;

internal class CreateMaintanceRecordHandler : IRequestHandler<CreateMaintanceRecordRequest, CreateMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IMapper _mapper;
    public CreateMaintanceRecordHandler(IUnitOfWork unitOfWork, IMaintanceRecordRepository maintanceRecordRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _maintanceRecordRepository = maintanceRecordRepository;
        _mapper = mapper;
    }
    public async Task<CreateMaintanceRecordResponse> Handle(CreateMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var maintanceRecord = _mapper.Map<MaintanceRecord>(request);
        _maintanceRecordRepository.Create(maintanceRecord);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateMaintanceRecordResponse>(maintanceRecord);
    }
}
