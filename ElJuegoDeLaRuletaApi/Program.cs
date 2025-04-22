using ElJuegoDeLaRuletaApi.Modelos;
using Microsoft.EntityFrameworkCore;
using ElJuegoDeLaRuletaApi.Controlador;
using ElJuegoDeLaRuletaApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INumberAndColor, Numberandcolor>(); //injectando servicio
builder.Services.AddScoped<IRuleta, Ruleta>(); //injectando servicio

builder.Services.AddDbContext<DataContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyMethod()
   .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();


