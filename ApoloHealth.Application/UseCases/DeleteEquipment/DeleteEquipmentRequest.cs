using ApoloHealth.Application.UseCases.UpdateEquipment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.DeleteEquipment;

public sealed record DeleteEquipmentRequest(Guid Id) :
        IRequest<DeleteEquipmentResponse>;
