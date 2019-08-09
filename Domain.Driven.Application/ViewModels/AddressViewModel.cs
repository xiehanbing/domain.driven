namespace Domain.Driven.Application.ViewModels
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressViewModel
    {
        public AddressViewModel(string province, string city, string county, string street, string zip)
        {
            Province = province;
            City = city;
            County = county;
            Street = street;
            Zip = zip;
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
        public string Zip { get; private set; }
    }
}