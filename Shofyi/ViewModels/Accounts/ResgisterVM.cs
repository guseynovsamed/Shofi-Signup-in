using System;
using System.ComponentModel.DataAnnotations;

namespace Shofyi.ViewModels.Accounts
{
	public class ResgisterVM
	{
        [Required]
		public string FullName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
		public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

