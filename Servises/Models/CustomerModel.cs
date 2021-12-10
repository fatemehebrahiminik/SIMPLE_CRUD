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
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Nation")]
        public int NationId { set; get; } 
        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Bank Account Number")]
        [Required]
        [RegularExpression("((\\d{4})-){3}\\d{4}", ErrorMessage = "correct format is 0000-0000-0000-0000.")]
        public string BankAccountNumber { set; get; }
    }
}
