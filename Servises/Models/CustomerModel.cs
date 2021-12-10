using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Servises.Models
{
   public class CustomerModel
    {
        public int? Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")] 
        public string LastName { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Phone Number")]
        public ulong? PhoneNumber { get; set; }
        [Display(Name = "Nation")]
        public int NationId { set; get; } 
        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Bank Account Number")] 
        public string BankAccountNumber { set; get; }
    }
}
