using System;
using Domain.Driven.Core.Commands;
using Domain.Driven.Domain.Validations.Student;

namespace Domain.Driven.Domain.Commands.Student
{
    /// <summary>
    /// 更新学生命令
    /// </summary>
    public  class UpdateStudentCommand:StudentCommand
    {
        public UpdateStudentCommand() { }
        public UpdateStudentCommand(Guid id,string name, string email, DateTime birthDate, string phone)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}