using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.GetAllEquipment;

public sealed class GetAllEquipmentMapper : Profile
{
    public GetAllEquipmentMapper() 
    {
        CreateMap<Equipment, GetAllEquipmentResponse>();
    }

}
