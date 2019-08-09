using Domain.Driven.Domain.Commands.Student;

namespace Domain.Driven.Domain.Validations.Student
{
    /// <summary>
    /// 更新学生命令模型  验证
    /// 继承 StudentValidation 基类
    /// </summary>
    public class UpdateStudentCommandValidation: StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation()
        {
            ValidateId();
            //可以自定义增加新的验证
            ValidateName();//验证姓名
            ValidateBirthDate();//验证年龄
            ValidateEmail();//验证邮箱
            ValidatePhone();//验证手机号
        }
    
    }
}