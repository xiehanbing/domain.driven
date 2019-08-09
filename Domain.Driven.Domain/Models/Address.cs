using System;
using Domain.Driven.Core.Models;
using Microsoft.EntityFrameworkCore;
using DomainCore = Domain.Driven.Core;
namespace Domain.Driven.Domain.Models
{
    /// <summary>
    /// 地址
    /// </summary>
    [Owned]
    public class Address : ValueObject<Address>
    {
        public Address() { }
        public Address(string province, string city, string county, string street, string zip)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
            this.Zip = zip;
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string  Zip { get; private set; }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }

}