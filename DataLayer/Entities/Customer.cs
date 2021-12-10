using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataLayer.Entities
{
    [Table("Tbl_Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public int NationId { set; get; }
        public Nation Nation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string BankAccountNumber { set; get; }
    }
}
