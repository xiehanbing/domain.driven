using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Driven.Data.Context;
using Domain.Driven.Domain.Interfaces.ReadRepository;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Data.Repository.Read
{
    /// <summary>
    /// 读库仓储
    /// </summary>
    public class ReadStudentRepository:ReadRepository<Student>,IReadStudentRepository
    {
        public ReadStudentRepository(StudyContext context) : base(context)
        {
        }

        public Student GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(o => o.Email.Equals(email));
        }
    }
}