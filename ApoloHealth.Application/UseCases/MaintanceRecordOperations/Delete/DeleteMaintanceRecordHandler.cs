using ApoloHealth.Application.UseCases.EquipmentOperations.Delete;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public class DeleteMaintanceRecordHandler : IRequestHandler<DeleteMaintanceRecordRequest, DeleteMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IMapper _mapper;
    public DeleteMaintanceRecordHandler(IUnitOfWork unitOfWork, IMaintanceRecordRepository maintanceRecordRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _maintanceRecordRepository = maintanceRecordRepository;
        _mapper = mapper;
    }
    public async Task<DeleteMaintanceRecordResponse> Handle(DeleteMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var maintanceRecord = await _maintanceRecordRepository.Get(request.Id, cancellationToken);

        if (maintanceRecord == null) { return default; }

        _maintanceRecordRepository.Delete(maintanceRecord);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteMaintanceRecordResponse>(maintanceRecord);
    }
}
