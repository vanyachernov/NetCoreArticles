using System.Net.Mime;
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

    public ArticlesController(
        IArticlesService articlesService,
        IImagesService imagesService)
    {
        _articlesService = articlesService;
        _imagesService = imagesService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticleResponse>>> GetArticles(CancellationToken token)
    {
        var articles = await _articlesService.GetAllArticlesAsync(token);
        
        return Ok(articles);
    }

    [HttpGet]
    [Route("{articleId:guid}")]
    public async Task<ActionResult<ArticleResponse>> GetArticleByIdentifier(
        [FromRoute] Guid articleId,
        CancellationToken token)
    {
        var article = await _articlesService.GetArticleByIdAsync(articleId, token);
            
        return article;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Article>> CreateArticle(
        [FromForm] ArticlesRequest article,
        CancellationToken token)
    {
        var imageProcessingResult = await _imagesService.CreateArticleImage(
            article.TitleImage,
            token);

        if (imageProcessingResult.IsFailure)
        {
            return BadRequest(imageProcessingResult.Error);
        }
        
        var newArticle = Article.Create(
            Guid.NewGuid(), 
            article.AuthorId, 
            null,
            article.Title, 
            article.Content,
            imageProcessingResult.Value);

        if (newArticle.IsFailure)
        {
            return BadRequest(newArticle.Error);
        }

        await _articlesService.CreateArticleAsync(
            newArticle.Value, 
            token);
         
         var isImagePerforming = await _imagesService.SaveImage(newArticle.Value.Id, imageProcessingResult.Value, token);

         if (!isImagePerforming)
         {
             return BadRequest("Image could not be uploaded to the database.");
         }

         return newArticle.Value;
    }
}