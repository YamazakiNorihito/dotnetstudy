using Grpc.Net.Client;
using GrpcContracts;
using ProtoBuf.Grpc.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:8100");
var client = channel.CreateGrpcService<IHelloService>();

var reply = await client.SayHello(
    new HelloRequest { Name = "GreeterClient" });

Console.WriteLine($"Greeting: {reply.Message}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();