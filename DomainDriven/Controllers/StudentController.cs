using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Driven.Application.Interfaces;
using Domain.Driven.Application.ViewModels;
using Domain.Driven.Core.Notifications;
using Domain.Driven.Domain.Commands.Student;
using Domain.Driven.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Driven.Ui.Controllers
{
    /// <summary>
    /// 学生管理
    /// </summary>
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IMemoryCache _cache;
        private readonly DomainNotificationHandler _notifications;
        public StudentController(IStudentAppService studentAppService, IMemoryCache cache, INotificationHandler<DomainNotification> notifications)
        {
            _studentAppService = studentAppService;
            _cache = cache;
            _notifications = (DomainNotificationHandler)notifications;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="studentViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            try
            {
                _cache.Remove("ErrorData");
                ViewBag.ErrorData = null; // 视图模型验证
                if (!ModelState.IsValid) return View(studentViewModel);

                #region 删除命令验证
                //添加命令验证，采用构造函数方法实例
                //RegisterStudentCommand registerStudentCommand = new RegisterStudentCommand(studentViewModel.Name, studentViewModel.Email, studentViewModel.BirthDate, studentViewModel.Phone); //如果命令无效，证明有错误
                //if (!registerStudentCommand.IsValid())
                //{
                //    List<string> errorInfo = new List<string>(); //获取到错误，请思考这个Result从哪里来的 
                //    foreach (var error in registerStudentCommand.ValidationResult.Errors)
                //    {
                //        errorInfo.Add(error.ErrorMessage);
                //    } //对错误进行记录，还需要抛给前台
                //    ViewBag.ErrorData = errorInfo; return View(studentViewModel);
                //}

                #endregion

                // 执行添加方法
                await _studentAppService.AddAsync(studentViewModel);
                if (!_notifications.HasNotifications())
                {
                    ViewBag.Sucesso = "Student Registered!";
                }

                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}