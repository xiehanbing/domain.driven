using Domain.Driven.Domain.Models;

namespace Domain.Driven.Domain.Interfaces.ReadRepository
{
    /// <summary>
    /// 只读库
    /// </summary>
    public interface IReadStudentRepository : IReadRepository<Student>
    {
        /// <summary>
        /// 根据邮箱获取数据
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        Student GetByEmail(string email);
    }
}