using Microsoft.EntityFrameworkCore;
using Data;
using Application;
using Application.Features.Auth.Services;
using System.Security.Claims;
using Application.Base.Extensions;
using Application.Features.Files.Options;
using Application.Features.Files.Services;
using Application.Features.Host.Mappings;
using Application.Features.Host.Options;
using Application.Features.Users.Mappigns;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

Modules.ConfigureOptions(builder.Services, builder.Configuration);
Modules.ConfigureServices(builder.Services, builder.Configuration);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});



builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache(); 
//builder.Services.AddProblemDetails();
builder.Services.AddAuthentication("Bearer");

builder.Services.AddAutoMapperServices(cfg =>
{
    cfg.AddProfile<ApplicationMappingProfile>();
    using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
    {
        cfg.AddProfile(new UsersMappingProfile(serviceProvider.GetService<UserIdentity>(),serviceProvider.GetService<FilesService>()));
    }
});

builder.Services.AddDbContext<RDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    opts.UseNpgsql(connectionString);
});


builder.Logging.ClearProviders();
builder.Logging.AddNLogWeb(new NLogAspNetCoreOptions
{
    ReplaceLoggerFactory = true
});

var app = builder.Build();

ClaimsPrincipal.ClaimsPrincipalSelector = () =>
			app.Services.GetService<IHttpContextAccessor>().HttpContext.User;

app.UseCors(MyAllowSpecificOrigins);

//var filesOptions = app.Services.GetService<IOptions<FilesOptions>>().Value;
//var hostOptions = app.Services.GetService<IOptions<UwOptions>>().Value;

//var isPathExists = Directory.Exists(filesOptions.StoragePath);

//if (!isPathExists)
//{
//    Directory.CreateDirectory(filesOptions.StoragePath);
//} 

//var path = Path.GetFullPath(filesOptions.StoragePath, app.Environment.ContentRootPath);

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(path),
//    RequestPath = hostOptions.MediaPath
//});


app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseMiddleware<AuthHandler>();

app.MapControllers();

app.Run();