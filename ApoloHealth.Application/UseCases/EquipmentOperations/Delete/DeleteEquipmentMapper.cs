using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public sealed class DeleteEquipmentMapper : Profile
{
    public DeleteEquipmentMapper()
    {
        CreateMap<DeleteEquipmentRequest, Equipment>();
        CreateMap<Equipment, DeleteEquipmentResponse>();
    }
}
