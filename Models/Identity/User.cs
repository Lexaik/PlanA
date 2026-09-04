using Microsoft.AspNetCore.Identity;

namespace PlanA.Models.Identity;

public class User : IdentityUser{
	public virtual string Fullname { get; set; }
	public virtual string Organization { get; set; }
	
}