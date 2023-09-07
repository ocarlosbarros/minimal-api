using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/* Adds swagger config */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseInMemoryDatabase("Customers"));

var app = builder.Build();

if  (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseRouting();
app.UseCustomerRoutes();
app.UseSwaggerUI();

app.Run();

