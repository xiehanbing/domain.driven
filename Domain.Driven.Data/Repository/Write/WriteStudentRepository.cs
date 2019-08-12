using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces.WriteRepository;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Data.Repository.Write
{
    /// <summary>
    /// 写库仓储
    /// </summary>
    public class WriteStudentRepository:WriteRepository<Student>,IWriteStudentRepository
    {
        public WriteStudentRepository(StudyContext context) : base(context)
        {
          
        }
    }
}