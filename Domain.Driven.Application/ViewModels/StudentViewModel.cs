using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Driven.Application.ViewModels
{
    /// <summary>
    /// 子领域Student的视图模型
    /// </summary>
    public class StudentViewModel
    {
        /// <summary>
        /// id 标识
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        public string  Email { get; set; }
        public string  Phone { get; set; }
        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        ///// <summary>
        ///// 地址
        ///// </summary>
        //public AddressViewModel Address { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get;  set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get;  set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string County { get;  set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get;  set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Zip { get;  set; }
    }
}