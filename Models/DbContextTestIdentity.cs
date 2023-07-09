using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace TestIdentity.Models;

public class DbContextTestIdentity : IdentityDbContext<UserModel>
{
    public DbSet<SaleModel> Sales { get; init; }
    public DbContextTestIdentity(DbContextOptions<DbContextTestIdentity> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        new UserModelConfig().Configure(builder.Entity<UserModel>());
        new SaleModelConfig().Configure(builder.Entity<SaleModel>());
    }
}