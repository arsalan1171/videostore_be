using Microsoft.EntityFrameworkCore;
using videostore_be.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using videostore_be.service;
using videostore_be.Repository;
using videostore_be.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<VideoStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MvcVideoContext")));
builder.Services.AddHttpClient();

//inject repositories to container
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Videos>, VideosRepository>();

//inject services to container
builder.Services.AddScoped<VideoService>();
builder.Services.AddScoped<RentalService>();
builder.Services.AddScoped<CustomerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Video Store API",
        Description = "An ASP.NET Core Web API for video store",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Arsalan Shahid",
            Url = new Uri("https://example.com/contact")
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();