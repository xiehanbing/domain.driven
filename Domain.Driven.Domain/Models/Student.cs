using System;
using DomainCore=Domain.Driven.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Driven.Domain.Models
{
    /// <summary>
    /// 定义 学生领域子对象
    /// </summary>
    public class Student: DomainCore.Models.Entity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected Student() { }
        /// <summary>
        /// 工造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="birthDate"></param>
        public Student(Guid id,string name,string email,string phone,DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
        }
        /// <summary>
        /// 名字
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public int  UserNo { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string  Sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string  Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string  Phone { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime  BirthDate { get; set; }
        /// <summary>
        /// 地址外键
        /// </summary>
      
        public Address Address { get; set; }
    }
   
}