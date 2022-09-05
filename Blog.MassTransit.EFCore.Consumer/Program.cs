using Blog.MassTransit.EFCore.Consumer;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
	x.AddConsumer<TestMessageConsumer>();
		
	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host("localhost", "/", h =>
		{
			h.Username("demo");
			h.Password("demo");
		});

		var builder = new DbContextOptionsBuilder()
			.UseNpgsql("Host=localhost;Port=5432;Database=audit;Username=demo;Password=demo", o => o.SetPostgresVersion(14, 0));

		cfg.UseEntityFrameworkCoreAuditStore(builder, "MTAuditEvents");

		cfg.ConfigureEndpoints(context);
	});
});

var app = builder.Build();
app.Run();