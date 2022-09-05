using Blog.MassTransit.EFCore.Data;
using MassTransit;

namespace Blog.MassTransit.EFCore.Consumer;

public class TestMessageConsumer : IConsumer<TestMessage>
{
	public async Task Consume(ConsumeContext<TestMessage> context)
	{
		Console.WriteLine($"Consuming message: {context.Message.Message}");
	}
}