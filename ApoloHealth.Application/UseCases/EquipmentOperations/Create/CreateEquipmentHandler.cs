using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Create;

internal class CreateEquipmentHandler : IRequestHandler<CreateEquipmentRequest, CreateEquipmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public CreateEquipmentHandler(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<CreateEquipmentResponse> Handle(CreateEquipmentRequest request, CancellationToken cancellationToken)
    {
        var equipment = _mapper.Map<Equipment>(request);
        _equipmentRepository.Create(equipment);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateEquipmentResponse>(equipment);
    }
}
