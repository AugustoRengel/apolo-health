using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Delete;

public sealed class DeleteAppointmentMapper : Profile
{
    public DeleteAppointmentMapper()
    {
        CreateMap<DeleteAppointmentRequest, Appointment>();
        CreateMap<Appointment, DeleteAppointmentResponse>();
    }
}
