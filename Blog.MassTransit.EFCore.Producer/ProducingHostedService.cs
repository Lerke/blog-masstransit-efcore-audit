using Blog.MassTransit.EFCore.Data;
using MassTransit;

namespace Blog.MassTransit.EFCore.Producer;

public class ProducingHostedService : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public ProducingHostedService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public Task StartAsync(CancellationToken cancellationToken)
	{
		Task.Run(async () =>
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				using var scope = _serviceProvider.CreateScope();
				var endpointProvider = scope.ServiceProvider.GetRequiredService<ISendEndpointProvider>();

				var endpoint = await endpointProvider.GetSendEndpoint(new($"queue:{nameof(TestMessage)}"));
				await endpoint.Send(new TestMessage
				{
					Message = $"Hello World - {Guid.NewGuid()}"
				});

				await Task.Delay(5000);
			}
		});

		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}