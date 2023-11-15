using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Update;

public sealed class UpdateAppointmentMapper : Profile
{
    public UpdateAppointmentMapper()
    {
        CreateMap<UpdateAppointmentRequest, Appointment>();
        CreateMap<Appointment, UpdateAppointmentResponse>();
    }
}
