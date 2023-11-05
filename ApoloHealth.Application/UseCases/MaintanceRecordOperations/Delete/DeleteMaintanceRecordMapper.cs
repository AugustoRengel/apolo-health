using ApoloHealth.Application.UseCases.EquipmentOperations.Delete;
using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed class DeleteMaintanceRecordMapper : Profile
{
    public DeleteMaintanceRecordMapper()
    {
        CreateMap<DeleteMaintanceRecordRequest, MaintanceRecord>();
        CreateMap<MaintanceRecord, DeleteMaintanceRecordResponse>();
    }
}
