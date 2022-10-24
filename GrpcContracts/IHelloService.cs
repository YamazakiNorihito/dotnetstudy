using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace GrpcContracts;

[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)] public string Name { get; init; }
}

[DataContract]
public class HelloReply
{
    [DataMember(Order = 1)] public string Message { get; init; }
}

[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    Task<HelloReply> SayHello(HelloRequest request, CallContext context = default);
}