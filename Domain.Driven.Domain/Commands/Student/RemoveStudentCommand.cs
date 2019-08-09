using System;
using Domain.Driven.Core.Commands;
using Domain.Driven.Domain.Validations.Student;

namespace Domain.Driven.Domain.Commands.Student
{
    /// <summary>
    /// 删除学生 命令
    /// </summary>
    public  class RemoveStudentCommand: StudentCommand
    {
        public RemoveStudentCommand() { }
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}