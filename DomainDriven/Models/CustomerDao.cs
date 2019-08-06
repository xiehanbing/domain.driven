namespace Domain.Driven.Ui.Models
{
    /// <summary>
    /// 领域对象持久化层
    /// </summary>
    public class CustomerDao
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CustomerModel GetCustomerModel(string id)
        {
            return new CustomerModel()
            {
                Id="1",
                Name = "domain driven",
                Email = "domain.driven@126.com"
            };
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static string SaveCutomer(CustomerModel customer)
        {
            return "success";
        }
    }
}