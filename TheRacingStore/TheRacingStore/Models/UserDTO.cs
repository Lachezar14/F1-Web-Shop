//using Data_Layer.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string FName { get;  set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string LName { get;  set; }
        
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Write a valid Email")]
        public string Email { get;  set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Write valid Phone Number")]
        public string Phone { get;  set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get;  set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get;  set; }
        
        [Required(ErrorMessage = "Postcode is required")]
        public string Postcode { get;  set; }
        
        public string Type { get;  set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get;  set; }
    }
}
