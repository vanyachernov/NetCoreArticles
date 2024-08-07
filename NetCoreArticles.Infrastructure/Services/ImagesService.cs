using System.Net.Mime;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Infrastructure.Services;

public class ImagesService : IImagesService
{
    private readonly IImagesRepository _imagesRepository;
    private readonly IWebHostEnvironment _environment;

    public ImagesService(
        IImagesRepository imagesRepository,
        IWebHostEnvironment environment)
    {
        _imagesRepository = imagesRepository;
        _environment = environment;
    }


    public async Task<Result<Image>> CreateImage(
        IFormFile imageFile,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var contentPath = Path.Combine(_environment.ContentRootPath, "StaticFiles/Images");
            
            if (!Directory.Exists(contentPath))
            {
                Directory.CreateDirectory(contentPath);
            }
            
            var ext = Path.GetExtension(imageFile.FileName);
            var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
            
            if (!allowedExtensions.Contains(ext))
            {
                var message = $"Only {string.Join(", ", allowedExtensions)} extensions are allowed";
                return Result.Failure<Image>(message);
            }

            var uniqueString = Guid.NewGuid().ToString();
            var newFileName = uniqueString + ext;
            var filePath = Path.Combine(contentPath, newFileName);
            
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream, cancellationToken);
            }
            
            var imageResult = Image.Create(newFileName);

            if (imageResult.IsFailure)
            {
                Result.Failure<Image>(imageResult.Error);
            }
            
            return Result.Success(imageResult.Value);
        }
        catch (Exception ex)
        {
            return Result.Failure<Image>(ex.Message);
        }
    }

    public async Task<bool> SaveImage(Guid articleId, Image image, CancellationToken cancellationToken = default)
    {
        return await _imagesRepository.AddAsync(articleId, image, cancellationToken);
    }
}