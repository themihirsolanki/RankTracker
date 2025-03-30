using Microsoft.AspNetCore.Mvc;
using RankTracker.API.Models;
using RankTracker.API.Models.Websites;
using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using System.Collections;

namespace RankTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebsitesController : ControllerBase
    {
        private ILogger<WebsitesController> _logger;
        private readonly IWebsiteRepository websiteRepository;

        public WebsitesController(ILogger<WebsitesController> logger, IWebsiteRepository websiteRepository)
        {
            _logger = logger;
            this.websiteRepository = websiteRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<WebsiteModel>> Get()
        {
            var model = new WebsiteModel();

            var websites = await websiteRepository.GetAllWebsitesAsync();

            if (websites.Any())
            { 
                var website = websites.First();
                model.Id = website.Id;
                model.Domain = website.Domain;

                return Ok(model);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(WebsiteModel model)
        {
            var existingWebsite = await websiteRepository.GetWebsiteByDomainAsync(model.Domain);
            
            if (existingWebsite != null) {
                return BadRequest("Website already exists");
            }

            var website = new Website { Domain = model.Domain };
            await websiteRepository.AddWebsiteAsync(website);

            // can return 201 with created with the new website and its URL
            return Ok(new { message = "Website added successfully." }); ;
        }
    }
}
