using ApoloHealth.Application.UseCases.EquipmentOperations.GetAll;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;

public sealed class GetAllMaintanceRecordHandler : IRequestHandler<GetAllMaintanceRecordRequest, List<GetAllMaintanceRecordResponse>>
{
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IMapper _mapper;
    public GetAllMaintanceRecordHandler(IMaintanceRecordRepository maintaceRecordRepository, IMapper mapper)
    {
        _maintanceRecordRepository = maintaceRecordRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllMaintanceRecordResponse>> Handle(GetAllMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var maintanceRecords = await _maintanceRecordRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllMaintanceRecordResponse>>(maintanceRecords);
    }
}
