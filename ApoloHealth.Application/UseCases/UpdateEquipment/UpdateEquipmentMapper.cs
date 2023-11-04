using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

public sealed class UpdateEquipmentMapper : Profile
{
    public UpdateEquipmentMapper()
    {
        CreateMap<UpdateEquipmentRequest, Equipment>()
            .ForMember(dest => dest.MaintanceRecords, opt =>
             opt.MapFrom(src => src.MaintanceRecordsDTO.Select(x =>
             new MaintanceRecord()
             {
                 EquipmentId = x.EquipmentId,
                 StartDate = x.StartDate,
                 EndDate = x.EndDate,
                 Technician = x.Technician,
                 InitialState = x.InitialState,
                 FinalState = x.FinalState,
                 ProblemDescription = x.ProblemDescription,
                 SolutionDescription = x.SolutionDescription
             }
             ))
          );
        CreateMap<Equipment, UpdateEquipmentResponse>();
    }
}
