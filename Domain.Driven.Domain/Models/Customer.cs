using System;

namespace Domain.Driven.Domain.Models
{
    /// <summary>
    /// 定义领域对象
    /// </summary>
    public class Customer
    {
        protected Customer()
        {

        }

        public Customer(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}