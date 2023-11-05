using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create
{
    public sealed class CreateEquipmentMapper : Profile
    {
        public CreateEquipmentMapper()
        {
            CreateMap<CreateEquipmentRequest, Equipment>();
            CreateMap<Equipment, CreateEquipmentResponse>();
        }
    }
}
