﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public sealed record DeleteExamRequest(Guid Id) :
        IRequest<DeleteExamResponse>;
