using ExchangeTracker.DAL;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Services;
using ExchangeTracker.Services.Interfaces;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders().AddConsole();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();

// AutoMapper configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding database logic
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddScoped<ICurrencyEntryRepository, CurrencyEntryRepository>();
builder.Services.AddScoped<ICurrencyEntryService, CurrencyEntryService>();

builder.Services.AddScoped<IXmlParserService, XmlParserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHangfire( config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHangfireServer();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Currency rates API");
    });
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.UseHangfireDashboard("/Hangfire");
RecurringJob.AddOrUpdate<IXmlParserService>("UpdateCurrencyRatesJob", x => x.UpdateCurrencyRatesAsync(), "0 10 * * 1-5");
app.Run();