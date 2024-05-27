using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContextSQL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

//Carregando Classes de Repositories
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<IGrupoRepository,GrupoRepository>();

builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<INotaFiscal, NotaFiscalRepository>();

builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensNota, ItensNotaRepository>();

builder.Services.AddScoped<ItensReqService>();
builder.Services.AddScoped<IItensReq, ItensReqRepository>();

builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IRequisicao, RequisicaoRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
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
