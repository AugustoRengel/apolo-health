using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;

namespace ApoloHealth.Persistence.Repositories;

internal class ExamRepository : BaseRepository<Exam>, IExamRepository
{
    public ExamRepository(AppDbContext context) : base(context) { }
}
