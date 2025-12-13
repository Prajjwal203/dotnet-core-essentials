var builder = WebApplication.CreateBuilder(args);

// Add MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Always enable Swagger (no conditions for now)
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();