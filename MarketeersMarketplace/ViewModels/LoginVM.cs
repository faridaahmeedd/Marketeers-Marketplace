﻿using System.ComponentModel.DataAnnotations;

namespace MarketeersMarketplace.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
