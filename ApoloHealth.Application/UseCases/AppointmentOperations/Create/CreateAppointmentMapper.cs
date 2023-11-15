using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Create
{
    public sealed class CreateAppointmentMapper : Profile
    {
        public CreateAppointmentMapper()
        {
            CreateMap<CreateAppointmentRequest, Appointment>();
            CreateMap<Appointment, CreateAppointmentResponse>();
        }
    }
}
