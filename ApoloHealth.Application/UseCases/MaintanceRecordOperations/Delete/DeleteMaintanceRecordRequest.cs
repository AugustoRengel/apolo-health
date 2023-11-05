using MediatR;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed record DeleteMaintanceRecordRequest(Guid Id) :
        IRequest<DeleteMaintanceRecordResponse>;
