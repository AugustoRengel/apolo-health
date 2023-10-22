using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

public sealed class UpdateEquipmentMapper : Profile
{
    public UpdateEquipmentMapper()
    {
        CreateMap<UpdateEquipmentRequest, Equipment>();
        CreateMap<Equipment, UpdateEquipmentResponse>();
    }
}
