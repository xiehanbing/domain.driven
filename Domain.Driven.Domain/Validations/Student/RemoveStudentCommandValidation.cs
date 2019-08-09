using Domain.Driven.Domain.Commands.Student;

namespace Domain.Driven.Domain.Validations.Student
{
    /// <summary>
    /// 删除学生命令模型 验证
    /// 继承与 StudentValidation
    /// </summary>
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();//验证id
                         //可以自定义增加新的验证
        }
    }
}