using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "Customer ID")]
        public string CustomerLongID { get; set; } //an 8-digit customer ID


        [Required(ErrorMessage = "Please enter your full name")]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Full name should only contain letters and spaces"),
         MaxLength(40)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [DataType(DataType.Text), MaxLength(100)]
        [Required]
        public string Address { get; set; }


        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address"), MaxLength(100)]
        public string Email { get; set; }


        [Required]
        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "Please enter a valid phone number"), MinLength(11),
         MaxLength(16)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Please select a gender")]
        public Gender Gender { get; set; }

        public string CustomerInfo
        {
            get; set;
        }
    }
}
