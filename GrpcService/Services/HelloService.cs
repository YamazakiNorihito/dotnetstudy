using GrpcContracts;
using ProtoBuf.Grpc;

namespace GrpcService.Services
{
    public class HelloService : IHelloService
    {
        public Task<GrpcContracts.HelloReply> SayHello(HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(
                new HelloReply
                {
                    Message = $"Hello {request.Name}"
                });
        }
    }
}