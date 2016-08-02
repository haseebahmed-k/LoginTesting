using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace testingLogin.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "email is required")]                 
        public string email { get; set; }


        [Required(ErrorMessage = "User name is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }






    }
}