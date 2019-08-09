using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Driven.Core.Notifications;
using Domain.Driven.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Driven.Ui.ViewComponents
{
    /// <summary>
    /// 弹框 视图组件
    /// </summary>
    public class AlertsViewComponent:ViewComponent
    {
        private readonly IMemoryCache _cache;

        private readonly DomainNotificationHandler _notifications;
        public AlertsViewComponent(IMemoryCache cache, INotificationHandler<DomainNotification> notifications)
        {
            _cache = cache;
            _notifications = (DomainNotificationHandler)notifications;
        }
        /// <summary>
        /// alerts 视图组件
        /// 可以同步 可以异步，注意方法名称
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var errorData = _cache.Get("ErrorData");
            //var notificacoes = await Task.Run(() =>
            //    (List<string>)errorData);
            var notificacoes = await Task.FromResult(_notifications.GetNotifications());
            //遍历错误信息，赋值给viewdata.modelstate
            //notificacoes?.ForEach(c=>ViewData.ModelState.TryAddModelError(string.Empty,c));
            notificacoes?.ForEach(c => ViewData.ModelState.TryAddModelError(string.Empty, c.Value));


            return View();
        }
    }
}