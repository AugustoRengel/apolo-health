using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.CustomerOperations.GetAll;

public sealed class GetAllCustomerMapper : Profile
{
    public GetAllCustomerMapper()
    {
        CreateMap<Customer, GetAllCustomerResponse>()
            .ForMember(dest => dest.AppointmentsDTO, opt =>
             opt.MapFrom(src => src.Appointments.Select(x =>
             new AppointmentDTO()
             {
                 Id = x.Id,
                 Title = x.Title,
                 Description = x.Description,
                 RoomNumber = x.RoomNumber,
                 StartDate = x.StartDate,
                 EndDate = x.EndDate,
                 WasDone = x.WasDone,
                 ExamId = x.ExamId,
                 CustomerId = x.CustomerId
             }
             ))
          );
    }

}