using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.GetAll;

public sealed class GetAllEmployeeMapper : Profile
{
    public GetAllEmployeeMapper()
    {
        CreateMap<Employee, GetAllEmployeeResponse>()
            .ForMember(dest => dest.EquipmentsDTO, opt =>
             opt.MapFrom(src => src.Equipments.Select(x =>
             new EquipmentDTO()
             {
                 Id = src.Id,
                 Name = x.Name,
                 Description = x.Description,
                 Type = x.Type,
                 Status = x.Status,
                 Maker = x.Maker,
                 FabricationDate = x.FabricationDate,
                 Sector = x.Sector,
                 MonthsBetweenPreventive = x.MonthsBetweenPreventive,
                 LastPreventiveDate = x.LastPreventiveDate,
                 MinutesOfPreventive = x.MinutesOfPreventive,
                 RequiresTechnician = x.RequiresTechnician
             }
             )))
            .ForMember(dest => dest.EquipmentsDTO, opt =>
             opt.MapFrom(src => src.Equipments.Select(x =>
             new EquipmentDTO()
             {
                 Id = src.Id,
                 Name = x.Name,
                 Description = x.Description,
                 Type = x.Type,
                 Status = x.Status,
                 Maker = x.Maker,
                 FabricationDate = x.FabricationDate,
                 Sector = x.Sector,
                 MonthsBetweenPreventive = x.MonthsBetweenPreventive,
                 LastPreventiveDate = x.LastPreventiveDate,
                 MinutesOfPreventive = x.MinutesOfPreventive,
                 RequiresTechnician = x.RequiresTechnician
             }
             )));
    }

}
