using MassTransit.EntityFrameworkCoreIntegration.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blog.MassTransit.EFCore.Data;

public class AuditTestContext : AuditDbContext
{
	public AuditTestContext(DbContextOptions options) : base(options, "MTAuditEvents")
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}

public class ContextFactory : IDesignTimeDbContextFactory<AuditTestContext>
{
	public AuditTestContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder();
		optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=audit;Username=demo;Password=demo",
			o => { o.SetPostgresVersion(14, 5); });

		return new(optionsBuilder.Options);

	}
}