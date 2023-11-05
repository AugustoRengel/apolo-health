using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Update;

public sealed class UpdateEquipmentMapper : Profile
{
    public UpdateEquipmentMapper()
    {
        CreateMap<UpdateEquipmentRequest, Equipment>()
            .ForMember(dest => dest.MaintanceRecords, opt =>
             opt.MapFrom(src => src.MaintanceRecordsDTO.Select(x =>
             new MaintanceRecord()
             {
                 EquipmentId = src.Id,
                 StartDate = x.StartDate,
                 EndDate = x.EndDate,
                 Technician = x.Technician,
                 InitialState = x.InitialState,
                 FinalState = x.FinalState,
                 ProblemDescription = x.ProblemDescription,
                 SolutionDescription = x.SolutionDescription,
                 WasDone = x.WasDone,
                 Type = x.Type
             }
             ))
          );
        CreateMap<Equipment, UpdateEquipmentResponse>();
    }
}
