using Lab13Web_NadiaTorres.API.Configuration;
using Lab13Web_NadiaTorres.Application.Configuration;
using Lab13Web_NadiaTorres.Application.MappersProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplicationService(configuration:builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly
    ));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
