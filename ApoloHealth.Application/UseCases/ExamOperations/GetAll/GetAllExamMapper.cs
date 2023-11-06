using ApoloHealth.Application.UseCases.ExamOperations.GetAll;
using ApoloHealth.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll;

public sealed class GetAllExamMapper : Profile
{
    public GetAllExamMapper()
    {
        CreateMap<Exam, GetAllExamResponse>();
    }

}
