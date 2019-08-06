using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Driven.Ui.Models;

namespace Domain.Driven.Ui.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SaveCustomer(string id, string name, string email, string birthdate)
        {
            CustomerModel customer = CustomerDao.GetCustomerModel(id);
            if (customer == null)
            {
                customer=new CustomerModel()
                {
                    Id=id
                };
            }

            if (name != null)
            {
                customer.Name = name;
            }

            if (email != null)
            {
                customer.Email = email;
            }
            //....还有其他的属性
            CustomerDao.SaveCutomer(customer);
        }
    }
}
