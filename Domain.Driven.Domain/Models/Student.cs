using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Driven.Domain.Models
{
    /// <summary>
    /// 定义 学生领域子对象
    /// </summary>
    public class Student
    {
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
    }
   
}