using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll;

public sealed class GetAllEquipmentHandler : IRequestHandler<GetAllEquipmentRequest, List<GetAllEquipmentResponse>>
{
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public GetAllEquipmentHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllEquipmentResponse>> Handle(GetAllEquipmentRequest request, CancellationToken cancellationToken)
    {
        var equipments = await _equipmentRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllEquipmentResponse>>(equipments);
    }
}