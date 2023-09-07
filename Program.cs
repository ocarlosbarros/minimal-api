var builder = WebApplication.CreateBuilder(args);

/* Adds swagger config */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if  (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/", () => "I came back to review .NET Core!");

app.UseSwaggerUI();

app.Run();
