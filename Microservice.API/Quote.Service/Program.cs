using MediatR;
using Microsoft.EntityFrameworkCore;
using Quote.Service.Data.DB_Context;
using Quote.Service.Data.Repository;
using Quote.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuoteDbContext>(options =>
{
    options.UseSqlServer(("name=ConnectionStrings:CometConnectionStr"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
});
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddTransient<IQuoteRepository, QuoteRepository>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
