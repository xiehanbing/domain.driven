using System;
using DomainCoreEvent=Domain.Driven.Core.Events;
namespace Domain.Driven.Domain.Events
{
    /// <summary>
    /// 学生事件 添加 模型
    /// </summary>
    public class StudentRegisteredEvent:DomainCoreEvent.Event
    {
        public StudentRegisteredEvent(Guid id, string name, string email, string phone, DateTime birthDate,string user="")
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            User = user;
            AggregateId = id;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string  Name { get;private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string  Email { get; private set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string  Phone { get; private set; }
        /// <summary>
        /// 标识
        /// </summary>
        public Guid Id { get;  set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; private set; }
    }
}