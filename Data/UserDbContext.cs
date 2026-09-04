using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanA.Context;
using PlanA.Models.Identity;

namespace PlanA.Data;

public class UserDbContext : IdentityDbContext<User, IdentityRole, string> {
	public UserDbContext(DbContextOptions<PlanADbContext> options)
		: base(options) {}

	protected override void OnModelCreating(ModelBuilder builder) {
		base.OnModelCreating(builder);
	}
}