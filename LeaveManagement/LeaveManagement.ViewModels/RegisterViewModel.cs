using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeaveManagement.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name{ get; set; }

        [Required]
        public string Contact{ get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string RoleName { get; set; }
        public bool IsSpecialPermission { get; set; }


    }
}