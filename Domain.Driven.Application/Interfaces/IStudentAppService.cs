using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Driven.Application.ViewModels;

namespace Domain.Driven.Application.Interfaces
{
    /// <summary>
    /// IStudentAppService 服务接口
    /// </summary>
    public interface IStudentAppService
    {
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StudentViewModel>> GetAllAsync();
        /// <summary>
        /// 获取 根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentViewModel> GetByIdAsync(Guid id);
        /// <summary>
        /// 添加 异步
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task AddAsync(StudentViewModel viewModel);

         
        /// <summary>
        /// 更新异步
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>

        Task UpdateAsync(StudentViewModel viewModel);
        /// <summary>
        /// 删除异步
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task RemoveAsync(Guid id);
    }
}