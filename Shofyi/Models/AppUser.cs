using System;
using Microsoft.AspNetCore.Identity;

namespace Shofyi.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
	}
}

