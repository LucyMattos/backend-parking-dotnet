using EstacionamentoAPI.Infra;
using EstacionamentoAPI.Repository.Contexto;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDIServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfileConfiguration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCoreCors();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();