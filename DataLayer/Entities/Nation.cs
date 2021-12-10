using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataLayer.Entities
{
    [Table("Tbl_Nation")]
    public class Nation
    {
        [Key]
        public int Id { set; get; }
        /// <summary>
        /// used for phone number validation check for example
        /// US
        /// IR
        /// </summary>
        public string NationType { set; get; }
        /// <summary>
        /// US(+1)
        /// IR(+98)
        /// </summary>
        public string NationTypeDesc { set; get; }
        /// <summary>
        /// nation code
        /// +98
        /// +1
        /// </summary>
        public string NationCode { set; get; }
        public ICollection<Customer> Customers { get; set; }
    }
}
