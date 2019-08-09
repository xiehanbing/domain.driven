using System;
using Domain.Driven.Core.Commands;
using Domain.Driven.Domain.Models;

namespace Domain.Driven.Domain.Commands.Student
{
    /// <summary>
    /// 定义一个抽象的 student 命令模型
    /// 继承command
    /// 这个模型的主要作用 就是用来创建命令动作的，不是用来实例化存储数据的，所以是一个抽象类
    /// </summary>
    public abstract class StudentCommand:Command
    {
        /// <summary>
        /// id 
        /// </summary>
        public Guid Id { get; protected set; } //注意：set 都是 protected
        /// <summary>
        /// 名字
        /// </summary>
        public string  Name { get;protected set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get;protected set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string  Phone { get;protected set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get;protected set; }
        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }
    }
}