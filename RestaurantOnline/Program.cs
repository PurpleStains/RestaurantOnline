using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RestaurantOnline;
using RestaurantOnline.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Host.ConfigureContainer<ContainerBuilder>(builder => 
builder.RegisterModule(new AutofacRestaurantModule(connectionString)));


builder.Services.AddControllers();
//builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
