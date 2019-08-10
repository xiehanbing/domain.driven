using System;
using Domain.Driven.Domain.Validations.Student;

namespace Domain.Driven.Domain.Commands.Student
{
    /// <summary>
    /// 注册一个添加 student 的命令
    /// 基础抽象学生命令模型
    /// </summary>
    public class RegisterStudentCommand:StudentCommand
    {
        public RegisterStudentCommand() { }
        public RegisterStudentCommand(string name, string email, DateTime birthDate, string phone)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
        }
        /// <summary>
        /// 重写基类中的是否有效方法
        /// 主要是为了引入命令验证 RegisterStudentCommandValidation
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        
    }
}