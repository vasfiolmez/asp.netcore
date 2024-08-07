using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BlogApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Mak. 10 karakter belirtiniz.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Paralo")]
        public string? Password { get; set; }
    }
}