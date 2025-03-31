using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;

namespace RankTracker.Core.Services;

public class KeywordService : IKeywordService
{
    private readonly IKeywordRepository keywordRepository;
    private readonly IWebsiteRepository websiteRepository;
    private readonly IEnumerable<IKeywordRankService> keywordRankServices;

    public KeywordService(IKeywordRepository keywordRepository, IWebsiteRepository websiteRepository, IEnumerable<IKeywordRankService> keywordRankServices)
    {
        this.keywordRepository = keywordRepository;
        this.websiteRepository = websiteRepository;
        this.keywordRankServices = keywordRankServices;
    }

    public async Task AddKeywordAsync(string keyword)
    {
        var websites = await websiteRepository.GetAllAsync();

        // Currently we assume we will have only one website so we have hard coded logic to get first website
        // else we would be passing via the client

        var website = websites.First();
        var newKeyword = new Keyword { 
                                Text = keyword, 
                                DateCreated = DateTime.Now, 
                                DateModified = DateTime.Now, 
                                WebsiteId = website.Id 
                        };

        await keywordRepository.AddAsync(newKeyword);

        foreach (var keywordRankService in keywordRankServices)
        {
            await keywordRankService.CheckKeywordRank(website.Domain, newKeyword.Id);
        }
    }

    public async Task RefreshRankings()
    {
        var websites = await websiteRepository.GetAllAsync();

        // Currently we assume we will have only one website so we have hard coded logic to get first website
        // else we would be passing via the client

        var website = websites.First();
        var keywords = await keywordRepository.GetAllAsync(website.Id);

        foreach (var keywordRankService in keywordRankServices)
        {
            foreach (var keyword in keywords)
            {
                await keywordRankService.CheckKeywordRank(website.Domain, keyword.Id);
            }
            
        }
    }
}
