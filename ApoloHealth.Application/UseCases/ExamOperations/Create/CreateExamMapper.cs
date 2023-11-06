using ApoloHealth.Domain.Entities;
using AutoMapper;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create
{
    public sealed class CreateExamMapper : Profile
    {
        public CreateExamMapper()
        {
            CreateMap<CreateExamRequest, Exam>();
            CreateMap<Exam, CreateExamResponse>();
        }
    }
}
