using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.DataAccess;
using NetCoreArticles.DataAccess.Entities;
using NetCoreArticles.DataAccess.Repositories;
using NetCoreArticles.Infrastructure.Features;
using NetCoreArticles.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext"));
    });
    
    builder.Services.AddAuthorization();

    builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
    
    builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
    builder.Services.AddScoped<ILikesRepository, LikesRepository>();
    builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<IArticlesService, ArticlesService>();
    builder.Services.AddScoped<ILikesService, LikesService>();
    builder.Services.AddScoped<IImagesService, ImagesService>();
    builder.Services.AddScoped<IUsersService, UsersService>();
    builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(app.Environment.ContentRootPath, "StaticFiles/Images")
        ),
        RequestPath = "/articles/images"
    });
    app.UseCors();
    app.MapControllers();
    app.Run();
}