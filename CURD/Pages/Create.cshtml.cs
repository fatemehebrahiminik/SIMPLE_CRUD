using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.DBContext;
using DataLayer.Entities;
using Servises.Models;
using Servises.Services;

namespace CURD.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly NationService _nationService;
        public CreateModel(CustomerService customerService, NationService nationService)
        {
            _customerService = customerService;
            _nationService = nationService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            Customer = id.HasValue ? await _customerService.GetCustomerAsync(id.Value) : new CustomerModel(); 
            if (Customer == null)
            {
                return NotFound();
            }
            var nations = await _nationService.GetAllNationsAsync();
            ViewData["NationId"] = new SelectList(nations, "Id", "NationTypeDesc");
            return Page();
        }

        [BindProperty]
        public CustomerModel Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                //check validate phone number
               // if (Customer.PhoneNumber.StartsWith('0'))
               //     Customer.PhoneNumber = Customer.PhoneNumber.Remove(0);
              //  if (Customer.PhoneNumber.StartsWith('+'))
              //      throw new Exception("invalid phone number format");
              if(!Customer.PhoneNumber.HasValue)
                    throw new Exception("phone number is requried");
                var nation = await _nationService.GetNationsAsync(Customer.NationId);
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phoneNumber = phoneNumberUtil.Parse(Customer.PhoneNumber.ToString(), nation.NationType);
                if (!phoneNumberUtil.IsValidNumber(phoneNumber))
                    throw new Exception("invalid phone number format");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Customer.PhoneNumber", ex.Message);
            }
            if (_customerService.CheckExitEmail(Customer.Id, Customer.Email))
                ModelState.AddModelError("Customer.Email", "This Email inserted before");
            if (!ModelState.IsValid)
            {
                var nations = await _nationService.GetAllNationsAsync();
                ViewData["NationId"] = new SelectList(nations, "Id", "NationTypeDesc");
                return Page();
            }
            if (!Customer.Id.HasValue)
               await _customerService.InsertCustomerAsync(Customer);
            else await _customerService.UpdateCustomerAsync(Customer);
            return RedirectToPage("./Index");
        }
    }
}