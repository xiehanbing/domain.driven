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

        Task<StudentViewModel> AddAsync(StudentViewModel viewModel);

        Task<bool> UpdateAsync(StudentViewModel viewModel);

        Task<bool> RemoveAsync(Guid id);
    }
}