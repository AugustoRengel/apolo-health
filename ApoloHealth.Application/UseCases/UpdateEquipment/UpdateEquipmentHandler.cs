using ApoloHealth.Application.UseCases.CreateEquipment;
using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

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

        equipment.Name = command.Name;
        equipment.Description = command.Description;

        _equipmentRepository.Update(equipment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateEquipmentResponse>(equipment);
    }
}
