using botWhatsapp;
using botWhatsapp.Application;
using botWhatsapp.Application.Business;
using botWhatsapp.Common.Enums;
using botWhatsapp.DataAccess;
using botWhatsapp.DataAccess.DbContext;
using GT.Transversal;
using GT.Transversal.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
String WebApiAssemblyName = typeof(Program).Assembly.GetName().Name!;
String XmlCommentsFilePath = Path.Combine(CommonConstants.BasePath, $"{WebApiAssemblyName}.xml");
ConfigurationManager configuration = builder.Configuration;
Byte appCode = configuration.GetPrimitive<Byte>("ApplicationCode");
BusinessInitializer<BotWhatsappError> initializer = ApplicationUtilities.GetInitializer(appCode);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services
    .AddDbContext<botDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddAutoMapper(typeof(MessagesBusiness))
    .AddBotWhatsappApplication(initializer)
    .AddBotWhatsappDataAccess();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = WebApiAssemblyName, Version = "v1" });
    c.IncludeXmlComments(XmlCommentsFilePath);
    c.MapWebTransferObjects();
});

#region HTTP request pipeline.
WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{WebApiAssemblyName} v1"));
app.UseGTMiddleware(initializer);
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion