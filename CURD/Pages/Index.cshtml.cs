using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.DBContext;
using DataLayer.Entities;
using Servises.Models;
using Servises.Services;

namespace CURD.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CustomerService _customerService;

        public IndexModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<CustomerModel> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _customerService.GetAllCustomersAsync();
        }
    }
}
