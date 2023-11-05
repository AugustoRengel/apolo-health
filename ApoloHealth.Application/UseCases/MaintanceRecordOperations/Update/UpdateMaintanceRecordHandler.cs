using ApoloHealth.Application.UseCases.EquipmentOperations.Update;
using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;

public class UpdateMaintanceRecordHandler : IRequestHandler<UpdateMaintanceRecordRequest, UpdateMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IMapper _mapper;
    public UpdateMaintanceRecordHandler(IUnitOfWork unitOfWork, IMaintanceRecordRepository maintanceRecordRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _maintanceRecordRepository = maintanceRecordRepository;
        _mapper = mapper;
    }
    public async Task<UpdateMaintanceRecordResponse> Handle(UpdateMaintanceRecordRequest command, CancellationToken cancellationToken)
    {
        var maintanceRecord = await _maintanceRecordRepository.Get(command.Id, cancellationToken);

        if (maintanceRecord == null) { return default; }

        var maintanceRecordUpdate = _mapper.Map<MaintanceRecord>(command);

        if (maintanceRecordUpdate.StartDate != null) { maintanceRecord.StartDate = maintanceRecordUpdate.StartDate; }
        if (maintanceRecordUpdate.EndDate != null) { maintanceRecord.EndDate = maintanceRecordUpdate.EndDate; }
        if (!string.IsNullOrEmpty(maintanceRecordUpdate.Technician)) { maintanceRecord.Technician = maintanceRecordUpdate.Technician; }
        if (maintanceRecordUpdate.InitialState != null) { maintanceRecord.InitialState = maintanceRecordUpdate.InitialState; }
        if (maintanceRecordUpdate.FinalState != null) { maintanceRecord.FinalState = maintanceRecordUpdate.FinalState; }
        if (!string.IsNullOrEmpty(maintanceRecordUpdate.ProblemDescription)) { maintanceRecord.ProblemDescription = maintanceRecordUpdate.ProblemDescription; }
        if (!string.IsNullOrEmpty(maintanceRecordUpdate.SolutionDescription)) { maintanceRecord.SolutionDescription = maintanceRecordUpdate.SolutionDescription; }
        if (maintanceRecordUpdate.WasDone != null) { maintanceRecord.WasDone = maintanceRecordUpdate.WasDone; }
        if (maintanceRecordUpdate.Type != null) { maintanceRecord.Type = maintanceRecordUpdate.Type; }

        _maintanceRecordRepository.Update(maintanceRecord);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateMaintanceRecordResponse>(maintanceRecord);
    }
}
