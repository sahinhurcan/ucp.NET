var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { 
        Title = "UCP API", 
        Version = "v1",
        Description = "Universal Commerce Protocol API - Merchant Implementation"
    });
    
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// TODO: Add your services here
// builder.Services.AddDbContext<YourDbContext>();
// builder.Services.AddScoped<ICheckoutService, CheckoutService>();
// builder.Services.AddScoped<IOrderService, OrderService>();
// builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UCP API v1");
        c.RoutePrefix = string.Empty; // Swagger at root
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
