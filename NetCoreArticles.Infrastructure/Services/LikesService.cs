using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Infrastructure.Services;

public class LikesService : ILikesService
{
    private readonly ILikesRepository _likesRepository;

    public LikesService(ILikesRepository likesRepository)
    {
        _likesRepository = likesRepository;
    }

    public async Task<Like> AddLikeToArticleAsync(
        Like like, 
        CancellationToken cancellationToken = default)
    {
        return await _likesRepository.AddAsync(
            like, 
            cancellationToken);
    }

    public async Task<bool> DeleteLikeAsync(
        Guid articleId, 
        Guid userId, 
        CancellationToken cancellationToken = default)
    {
        return await _likesRepository.DeleteAsync(
            articleId, 
            userId, 
            cancellationToken);
    }
}