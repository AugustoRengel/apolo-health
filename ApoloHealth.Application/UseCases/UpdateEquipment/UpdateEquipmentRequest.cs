using ApoloHealth.Application.UseCases.CreateEquipment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

public sealed record UpdateEquipmentRequest(Guid Id, string Name, string Description) :
        IRequest<UpdateEquipmentResponse>;
