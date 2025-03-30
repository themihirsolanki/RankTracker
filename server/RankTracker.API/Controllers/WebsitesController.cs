using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models.Websites;
using RankTracker.Core.Repositories;
using RankTracker.Core.Services;

namespace RankTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WebsitesController : ControllerBase
{
    private ILogger<WebsitesController> _logger;
    
    public WebsitesController(ILogger<WebsitesController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public async Task<ActionResult<WebsiteModel>> Get([FromServices] IWebsiteRepository websiteRepository)
    {
        var model = new WebsiteModel();

        var websites = await websiteRepository.GetAllAsync();

        if (websites.Any())
        { 
            var website = websites.First();
            model.Domain = website.Domain;

            return Ok(model);
        }
        else {
            return NotFound();
        }
    }

    [HttpPost()]
    public async Task<IActionResult> Post(WebsiteModel model, [FromServices] IWebsiteService websiteService)
    {
        try
        {
            await websiteService.Add(model.Domain);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest($"Website already exists. {ex.Message}");
        }

        // can return 201 with created with the new website and its URL
        return Ok(new { message = "Website added successfully." }); ;
    }
}
