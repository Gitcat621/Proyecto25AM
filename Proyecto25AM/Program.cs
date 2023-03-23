using Proyecto25AM;

var builder = WebApplication.CreateBuilder(args);





// Configure the HTTP request pipeline.

var startup = new startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();
