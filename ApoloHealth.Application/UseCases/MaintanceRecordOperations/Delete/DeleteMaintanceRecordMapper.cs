using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed class DeleteMaintanceRecordMapper : Profile
{
    public DeleteMaintanceRecordMapper()
    {
        CreateMap<DeleteMaintanceRecordRequest, MaintanceRecord>();
        CreateMap<MaintanceRecord, DeleteMaintanceRecordResponse>();
    }
}
