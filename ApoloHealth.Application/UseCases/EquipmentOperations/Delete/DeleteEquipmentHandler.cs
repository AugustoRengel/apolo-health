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

public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentRequest, DeleteEquipmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IMapper _mapper;
    public DeleteEquipmentHandler(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository, IMaintanceRecordRepository maintanceRecordRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _equipmentRepository = equipmentRepository;
        _maintanceRecordRepository = maintanceRecordRepository;
        _mapper = mapper;
    }
    public async Task<DeleteEquipmentResponse> Handle(DeleteEquipmentRequest request, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.Get(request.Id, cancellationToken);

        if (equipment == null) { return default; }

        foreach(var record in equipment.MaintanceRecords)
        {
            _maintanceRecordRepository.Delete(record);
        }
        _equipmentRepository.Delete(equipment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteEquipmentResponse>(equipment);
    }
}
