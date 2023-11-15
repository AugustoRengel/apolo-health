using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.GetAll;

public sealed class GetAllAppointmentMapper : Profile
{
    public GetAllAppointmentMapper()
    {
        CreateMap<Appointment, GetAllAppointmentResponse>();
    }

}
