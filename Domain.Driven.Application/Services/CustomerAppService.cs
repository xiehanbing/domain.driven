using System;
using System.Collections.Generic;
using Domain.Driven.Application.Interfaces;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Domain.Interfaces;

namespace Domain.Driven.Application.Services
{
    /// <summary>
    /// CustomerAppService 服务接口实现类,继承 服务接口
    /// 通过 DTO 实现视图模型和领域模型的关系处理
    /// 作为调度者，协调领域层和基础层，
    /// 这里只是做一个面向用户用例的服务接口,不包含业务规则或者知识
    /// </summary>
    public class CustomerAppService:ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Dispose()
        {
           GC.SuppressFinalize(this);
        }

        public void Regiter(CustomerViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return null;
        }

        public CustomerViewModel GetById(Guid id)
        {
            return null;
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}