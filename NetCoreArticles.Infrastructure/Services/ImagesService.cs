using System.Net.Mime;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Infrastructure.Services;

public class ImagesService : IImagesService
{
    private readonly IImagesRepository _imagesRepository;

    public ImagesService(IImagesRepository imagesRepository)
    {
        _imagesRepository = imagesRepository;
    }


    public async Task<Result<Image>> CreateImage(
        IFormFile imageFile, 
        string path,
        CancellationToken cancellationToken = default)

    {
        try
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var filePath = Path.Combine(path, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream, cancellationToken);
            }

            var image = Image.Create(filePath);

            return image;
        }
        catch (Exception e)
        {
            return Result.Failure<Image>(e.Message);
        }
    }
}