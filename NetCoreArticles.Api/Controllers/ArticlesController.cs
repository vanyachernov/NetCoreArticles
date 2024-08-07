using Microsoft.AspNetCore.Mvc;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Api.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : ControllerBase
{
    private readonly IArticlesService _articlesService;
    private readonly IImagesService _imagesService;
    private readonly string _staticFilesPath =
        Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/Images");

    public ArticlesController(
        IArticlesService articlesService,
        IImagesService imagesService)
    {
        _articlesService = articlesService;
        _imagesService = imagesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticles(CancellationToken token)
    {
        var articles = await _articlesService.GetAllArticlesAsync(token);
        
        return Ok(articles);
    }

    [HttpGet]
    [Route("{articleId:guid}")]
    public async Task<ActionResult<Article>> GetArticleByIdentifier(
        [FromRoute] Guid articleId,
        CancellationToken token)
    {
        var article = await _articlesService.GetArticleByIdAsync(articleId, token);
            
        return article;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Article>> CreateArticle(
        [FromBody] ArticlesRequest article,
        CancellationToken token)
    {
        var imageProcessingResult = await _imagesService.CreateImage(
            article.TitleImage, 
            _staticFilesPath, 
            token);

        if (imageProcessingResult.IsFailure)
        {
            return BadRequest(imageProcessingResult.Error);
        }
        
        var newArticle = Article.Create(
            Guid.NewGuid(), 
            article.AuthorId, 
            article.Title, 
            article.Content,
            imageProcessingResult.Value);

        if (newArticle.IsFailure)
        {
            return BadRequest(newArticle.Error);
        }

        return await _articlesService.CreateArticleAsync(
            newArticle.Value, 
            token);
    }
}