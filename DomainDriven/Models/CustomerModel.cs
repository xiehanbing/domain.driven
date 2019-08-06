using System;

namespace Domain.Driven.Ui.Models
{
    /// <summary>
    /// customer 领域对象
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// id 标示
        /// </summary>
        public string  Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string  Email { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime  BirthDate { get; set; }
    }
}