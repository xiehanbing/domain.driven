using System.Linq;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Data.Repository
{
    /// <summary>
    /// 学生仓储
    /// </summary>
    public class StudentRepository: Repository<Student>,IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {
        }

        public Student GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(o => o.Email.Equals(email));
        }
    }
}