using Dapr.Client;
using Greeter.Interfaces;
using Grpc.Core;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.Configuration;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.ClientFactory;
using ProtoBuf.Grpc.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();
//builder.Services.AddCodeFirstGrpcClient<IGreeterService>(clientFactoryOptions =>
//{
//    // Address of grpc server
//    //clientFactoryOptions.Address = new Uri("http://localhost:50001");

//    // another channel options (based on best practices docs on https://docs.microsoft.com/en-us/aspnet/core/grpc/performance?view=aspnetcore-6.0)
//    clientFactoryOptions.ChannelOptionsActions.Add(channelOptions =>
//    {
//        channelOptions.HttpHandler = new SocketsHttpHandler()
//        {
//            // keeps connection alive
//            PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
//            KeepAlivePingDelay = TimeSpan.FromSeconds(60),
//            KeepAlivePingTimeout = TimeSpan.FromSeconds(30),

//            // allows channel to add additional HTTP/2 connections
//            EnableMultipleHttp2Connections = true
//        };
//    });
//});

builder.Services.AddSingleton(_ => DaprClient.CreateInvocationInvoker("greeter-service").CreateGrpcService<IGreeterService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/greeter/sayhello", async (IGreeterService greeterService, string name) =>
{
    var request = new HelloRequest { Name = name };
    var reply = await greeterService.SayHelloAsync(request);
    return Results.Ok(reply.Message);
})
.WithName("Greeter.SayHello")
.WithOpenApi();

app.Run();
