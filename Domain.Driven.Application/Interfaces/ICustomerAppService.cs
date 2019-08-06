using System;
using System.Collections.Generic;
using Domain.Driven.Application.ViewModels;

namespace Domain.Driven.Application.Interfaces
{
    /// <summary>
    /// 定义ICustomerAppService 服务接口
    /// 并继承IDisposable ，显示释放资源
    /// 注意这里我们使用的对象，是视图对象模型
    /// </summary>
    public interface ICustomerAppService:IDisposable
    {
        void Regiter(CustomerViewModel customerViewModel);

        IEnumerable<CustomerViewModel> GetAll();

        CustomerViewModel GetById(Guid id);

        void Update(CustomerViewModel customerViewModel);

        void Remove(Guid id);
    }
}