using Greeter.Interfaces;
using ProtoBuf.Grpc;

namespace Greeter.Service.Services
{
    public class GreeterService : IGreeterService
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}