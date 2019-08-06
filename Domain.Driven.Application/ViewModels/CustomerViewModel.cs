using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Driven.Application.ViewModels
{
    /// <summary>
    /// 子领域Customer的视图模型
    /// </summary>
    public class CustomerViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string  Name { get; set; }
        /// <summary>
        /// email
        /// </summary>
        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string  Email { get; set; }
        /// <summary>
        /// birthdate
        /// </summary>
        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date,ErrorMessage = "Date em formato invalido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

    }
}