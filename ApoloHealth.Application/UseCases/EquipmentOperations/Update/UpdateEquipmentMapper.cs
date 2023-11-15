using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public sealed class UpdateEquipmentMapper : Profile
{
    public UpdateEquipmentMapper()
    {
        CreateMap<UpdateEquipmentRequest, Equipment>();
        CreateMap<Equipment, UpdateEquipmentResponse>();
    }
}
