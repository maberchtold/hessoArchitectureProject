// File: Program.cs
using DAL;
using Microsoft.EntityFrameworkCore;
using WebAPI_PrintPayment.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services
builder.Services.AddScoped<IPrintPaymentHelper, PrintPaymentHelper>();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<PrintPaymentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Seed(services);
}

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

// Local seed function
void Seed(IServiceProvider serviceProvider)
{
    using var context = new PrintPaymentContext(
        serviceProvider.GetRequiredService<DbContextOptions<PrintPaymentContext>>());

    context.Database.EnsureCreated(); // Optionally use .Migrate() in production
}
