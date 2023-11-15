using ApoloHealth.Application.UseCases.AppointmentOperations.Delete;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Delete;

public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentRequest, DeleteAppointmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public DeleteAppointmentHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<DeleteAppointmentResponse> Handle(DeleteAppointmentRequest request, CancellationToken cancellationToken)
    {
        var Appointment = await _appointmentRepository.Get(request.Id, cancellationToken);

        if (Appointment == null) { return default; }

        _appointmentRepository.Delete(Appointment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteAppointmentResponse>(Appointment);
    }
}
