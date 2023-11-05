using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Delete;

public class DeleteEquipmentHandler : IRequestHandler<DeleteEquipmentRequest, DeleteEquipmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public DeleteEquipmentHandler(IUnitOfWork unitOfWork, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<DeleteEquipmentResponse> Handle(DeleteEquipmentRequest request, CancellationToken cancellationToken)
    {
        var equipment = await _equipmentRepository.Get(request.Id, cancellationToken);

        if (equipment == null) { return default; }

        _equipmentRepository.Delete(equipment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteEquipmentResponse>(equipment);
    }
}
