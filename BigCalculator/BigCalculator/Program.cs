using BigCalculator.Adapter;
using BigCalculator.Calculus;
using BigCalculator.Service;
using BigCalculator.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICompute, Compute>();
builder.Services.AddTransient<Validator>();
builder.Services.AddTransient<Parser>();
builder.Services.AddTransient<IConvertor, Convertor>();
builder.Services.AddTransient<IComparator, Comparator>();
builder.Services.AddTransient<ICalculation, Calculation>();
builder.Services.AddTransient<ICalculator, Calculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
