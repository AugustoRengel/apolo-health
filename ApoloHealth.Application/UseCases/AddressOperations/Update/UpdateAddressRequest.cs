using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.AddressOperations.Update;

public sealed record UpdateAddressRequest(
    Guid Id,
    string? Street,
    string? City,
    string? State,
    string? PostalCode,
    string? Country,
    Guid? PersonId
    ) : IRequest<UpdateAddressResponse>;