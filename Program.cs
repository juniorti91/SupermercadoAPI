using SupermercadoAPI.Repository;
using SupermercadoAPI.Repository.Interfaces;
using SupermercadoAPI.Services;
using SupermercadoAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Injeção de dependência dos Services
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IItemCompraService, ItemCompraService>();
builder.Services.AddScoped<IItemVendaService, ItemVendaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IVendaService, VendaService>();

// Injeção de dependência dos Repositóries
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IItemCompraRepository, ItemCompraRepository>();
builder.Services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();

// Configurar AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurar controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Kestrel para escutar na porta 5047
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5048); // Permite conexões de qualquer IP na porta 5048
});

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalAndExternal",
        policyBuilder => policyBuilder
            .WithOrigins(
                "http://localhost:5048",
                "http://191.252.103.130:8083",
                "http://191.252.103.190:8083" // Novo IP
            )
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar o uso do Swagger em Produção
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
