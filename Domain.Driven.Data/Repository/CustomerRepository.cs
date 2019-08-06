using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Data.Repository
{
    /// <summary>
    /// customer 仓储 ，操作对象还是领域对象
    /// </summary>
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        //对特例接口进行实现
        public Customer GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}