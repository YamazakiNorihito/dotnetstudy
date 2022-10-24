using System.Net;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcClient.Data;
using GrpcContracts;
using ProtoBuf.Grpc.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


//builder.Services.AddGrpcClient<IHelloService>(o =>
//{
//    o.Address = new Uri("https://localhost:8100");
//});


var gRpcWebHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())
    { HttpVersion = HttpVersion.Version11 };
builder.Services.AddSingleton<ChannelBase>(_
    => GrpcChannel.ForAddress("https://localhost:8100", new GrpcChannelOptions { HttpHandler = gRpcWebHandler }));

builder.Services.AddSingleton(serviceProvider =>
{
    var channel = serviceProvider.GetRequiredService<ChannelBase>();
    return channel.CreateGrpcService<IHelloService>();
});

//builder.Services
//    .AddGrpcClient<IHelloService>(options =>
//    {
//        options.Address = new Uri("https://localhost:8100");
//    })
//    .ConfigurePrimaryHttpMessageHandler(
//        () => new GrpcWebHandler(new HttpClientHandler()));

//builder.Services.AddLogging(builder => builder
//    .AddBrowserConsole()
//    .SetMinimumLevel(LogLevel.Trace));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();