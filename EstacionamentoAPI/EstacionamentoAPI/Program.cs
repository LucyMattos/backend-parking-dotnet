using EstacionamentoAPI.Domain.Validacoes;
using EstacionamentoAPI.Infra;
using EstacionamentoAPI.Repository.Contexto;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EstacionamentoDB");
builder.Services.AddDbContext<EstacionamentoContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly("EstacionamentoAPI.Repository");
        opt.MigrationsHistoryTable("Migrations", "Configuration");
    });
}, ServiceLifetime.Transient);

builder.Services.AddMvc()
                    .ConfigureEstacionamentoApiBehavior()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EmpresaValidador>());

builder.Services.AddDIServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{ 
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EstacionamentoAPI",
        Version = "v1",
        Description = "API REST desenvolvida em .NET 6  para gerenciar um estacionamento de carros e motos.",
        Contact = new OpenApiContact
        {
            Name = "Lucy Nascimento Mattos",
            Email = "lucymattos32@hotmail.com",
            Url = new Uri("https://www.linkedin.com/in/lucymattos/")
        }

    });
    c.EnableAnnotations();
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfileConfiguration));
    builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseEstacionamentoApiKey();
    app.UseCoreCors();
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();