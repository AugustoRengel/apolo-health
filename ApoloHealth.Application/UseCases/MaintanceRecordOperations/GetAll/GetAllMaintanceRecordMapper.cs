using ApoloHealth.Application.UseCases.ExamOperations.GetAll;
using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;

public sealed class GetAllMaintanceRecordMapper : Profile
{
    public GetAllMaintanceRecordMapper()
    {
        CreateMap<MaintanceRecord, GetAllMaintanceRecordResponse>();
    }

}
