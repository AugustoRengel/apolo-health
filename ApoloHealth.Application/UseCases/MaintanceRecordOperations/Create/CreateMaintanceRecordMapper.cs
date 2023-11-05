using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;

public sealed class ClassMapper : Profile
{
    public ClassMapper()
    {
        CreateMap<CreateMaintanceRecordRequest, MaintanceRecord>();
        CreateMap<MaintanceRecord, CreateMaintanceRecordResponse>();
    }
}
