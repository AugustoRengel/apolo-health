using ApoloHealth.Application.UseCases.EquipmentOperations.Update;
using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;

public sealed class UpdateMaintanceRecordMapper : Profile
{
    public UpdateMaintanceRecordMapper()
    {
        CreateMap<UpdateMaintanceRecordRequest, MaintanceRecord>();
        CreateMap<MaintanceRecord, UpdateMaintanceRecordResponse>();
    }
}
