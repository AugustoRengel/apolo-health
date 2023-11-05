using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Update;

public class UpdateEquipmentHandler : IRequestHandler<UpdateEquipmentRequest, UpdateEquipmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public UpdateEquipmentHandler(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<UpdateEquipmentResponse> Handle(UpdateEquipmentRequest command, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.Get(command.Id, cancellationToken);

        if (equipment == null) { return default; }
        var equipmentUpdate = _mapper.Map<Equipment>(command);
        if (!string.IsNullOrEmpty(equipmentUpdate.Name)) { equipment.Name = equipmentUpdate.Name; }
        if (!string.IsNullOrEmpty(equipmentUpdate.Description)) { equipment.Description = equipmentUpdate.Description; }
        if (equipmentUpdate.Status != null) { equipment.Status = equipmentUpdate.Status; }
        if (!string.IsNullOrEmpty(equipmentUpdate.Maker)) { equipment.Maker = equipmentUpdate.Maker; }
        if (equipmentUpdate.FabricationDate != null) { equipment.FabricationDate = equipmentUpdate.FabricationDate; }
        if (equipmentUpdate.Name != null) { equipment.Name = equipmentUpdate.Name; }
        if (equipmentUpdate.MaintanceRecords != null) { equipment.MaintanceRecords = equipmentUpdate.MaintanceRecords; }

        _equipmentRepository.Update(equipment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateEquipmentResponse>(equipment);
    }
}
