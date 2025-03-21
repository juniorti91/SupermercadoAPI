using SupermercadoAPI.Repository;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services;
using SupermercadoAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Injeção de dependência
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurar controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
