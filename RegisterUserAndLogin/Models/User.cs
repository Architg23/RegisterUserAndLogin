using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserandLogin.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [Display(Name = "Email id")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not Valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Password is not Valid.")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Contact")]
        [RegularExpression(@"^\d{10}$" , ErrorMessage = " Contact must be of 10 digit.")]
        public string Contact { get; set; }
    }
}