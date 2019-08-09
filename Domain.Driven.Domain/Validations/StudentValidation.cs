using System;
using Domain.Driven.Domain.Commands.Student;
using FluentValidation;

namespace Domain.Driven.Domain.Validations
{
    /// <summary>
    /// 定义基于studentcommand 的抽象基类 studentvalidation
    /// 继承 抽象类 AbstractValidator
    /// 注意需要引用 FluentValidation
    ///  注意这里的 T 是命令模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StudentValidation<T>:AbstractValidator<T> where T : StudentCommand
    {
        /// <summary>
        /// 验证name
        /// </summary>
        protected void ValidateName()
        {
            //定义规则 c 为当前的 studentcommand 类
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("姓名不能为空")//判断不能为空 ，如果为空显示message
                .Length(2, 100).WithMessage("姓名在2~100个字符之间");//定义长度
        }
        /// <summary>
        /// 验证年龄
        /// </summary>
        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("学生应该在14岁以上");
        }
        /// <summary>
        /// 验证email
        /// </summary>
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("邮箱不符合规范");
        }
        /// <summary>
        /// 验证手机号
        /// </summary>
        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                .NotEmpty()
                .Must(HavePhone)
                .WithMessage("手机号应该11位");
        }
        /// <summary>
        /// 验证guid
        /// </summary>
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        /// <summary>
        /// 表达式 出生日期
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-14);
        }
        /// <summary>
        /// 手机号验证表达式
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        protected static bool HavePhone(string phone)
        {
            return phone.Length == 11;
        }
    }
}