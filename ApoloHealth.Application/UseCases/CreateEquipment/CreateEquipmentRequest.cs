using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.CreateEquipment;

public sealed record CreateEquipmentRequest(string Name, string Description) : 
    IRequest<CreateEquipmentResponse>;
