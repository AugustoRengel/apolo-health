using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public sealed class UpdateExamMapper : Profile
{
    public UpdateExamMapper()
    {
        CreateMap<UpdateExamRequest, Exam>();
        CreateMap<Exam, UpdateExamResponse>();
    }
}
