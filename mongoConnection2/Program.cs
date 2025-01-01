using mongoConnection2.Models;
using mongoConnection2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MyDb")
    );
//resolving the CategoryService dependency here
builder.Services.AddTransient<ICategoryService, CategoryService>();
//resolving the CategoryService dependency here
builder.Services.AddTransient<IProductService, ProductService>();
//resolving the CategoryService dependency here
builder.Services.AddTransient<ICustomerService, CustomerService>();
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
