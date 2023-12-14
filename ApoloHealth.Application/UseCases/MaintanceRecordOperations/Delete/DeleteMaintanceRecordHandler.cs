using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public class DeleteMaintanceRecordHandler : IRequestHandler<DeleteMaintanceRecordRequest, DeleteMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public DeleteMaintanceRecordHandler(IUnitOfWork unitOfWork, IMaintanceRecordRepository maintanceRecordRepository, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _maintanceRecordRepository = maintanceRecordRepository;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<DeleteMaintanceRecordResponse> Handle(DeleteMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var maintanceRecord = await _maintanceRecordRepository.Get(request.Id, cancellationToken);

        if (maintanceRecord == null) { return default; }

        if (maintanceRecord.WasDone)
        {
            var equipment = await _equipmentRepository.Get(maintanceRecord.EquipmentId, cancellationToken);
            if (equipment != null)
            {
                var maintanceRecordsOfEquipment = equipment.MaintanceRecords.OrderByDescending(m => m.StartDate);
                if (maintanceRecordsOfEquipment.FirstOrDefault()?.Id == maintanceRecord.Id)
                {
                    equipment.Status = maintanceRecord.InitialState;
                    if(equipment.MaintanceRecords.Count > 1)
                    {
                        equipment.LastPreventiveDate = maintanceRecordsOfEquipment.ToList()[equipment.MaintanceRecords.Count - 2].EndDate;
                    }
                    else
                    {
                        equipment.LastPreventiveDate = DateTime.MinValue;
                    }
                    equipment.DateUpdated = DateTime.UtcNow;
                    _equipmentRepository.Update(equipment);
                }
            }
        }

        _maintanceRecordRepository.Delete(maintanceRecord);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteMaintanceRecordResponse>(maintanceRecord);
    }
}
