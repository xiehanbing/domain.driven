using Domain.Driven.Data.Context;
using Domain.Driven.Data.Repository.Read;
using Domain.Driven.Domain.Interfaces;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Data.Repository
{
    /// <summary>
    /// customer 仓储 ，操作对象还是领域对象
    /// </summary>
    public class CustomerRepository:ReadRepository<Customer>, ICustomerRepository
    {
        //对特例接口进行实现
        public Customer GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public CustomerRepository(StudyContext context) : base(context)
        {
        }
    }
}