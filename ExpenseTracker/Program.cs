var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(); //identiifca el controlador 

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

app.MapControllers();

app.Run();

