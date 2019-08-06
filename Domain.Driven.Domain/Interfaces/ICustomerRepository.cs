using Domain.Driven.Domain.Models;

namespace Domain.Driven.Domain.Interfaces
{
    /// <summary>
    /// ICustomerRepository 接口 /// 注意，这里我们用到的业务对象，是领域对象
    /// </summary>
    public interface ICustomerRepository:IRepository<Customer>
    {
        /// <summary>
        /// 一些Customer独有的接口
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Customer GetByEmail(string email);
    }
}