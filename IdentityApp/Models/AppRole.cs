using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class AppRole : IdentityRole
    {
        public string FullName { get; set; } = string.Empty;

    }
}