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
        var website = await GetWebsite();

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

    public async Task DeleteKeywordAsync(int id)
    {
        var keyword = await keywordRepository.GetAsync(id);
        await keywordRepository.RemoveAsync(keyword);
    }

    public async Task RefreshRanking(int id)
    {
        var website = await GetWebsite();

        var keyword = await keywordRepository.GetAsync(id);

        foreach (var keywordRankService in keywordRankServices)
        {
            await keywordRankService.CheckKeywordRank(website.Domain, keyword.Id);
        }
    }

    public async Task RefreshRankings()
    {
        var website = await GetWebsite();

        var keywords = await keywordRepository.GetAllAsync(website.Id);

        foreach (var keywordRankService in keywordRankServices)
        {
            foreach (var keyword in keywords)
            {
                await keywordRankService.CheckKeywordRank(website.Domain, keyword.Id);
            }
            
        }
    }

    private async Task<Website> GetWebsite() 
    {
        var websites = await websiteRepository.GetAllAsync();

        // Currently we assume we will have only one website so we have hard coded logic to get first website
        // else we would be passing via the client

        return websites.First();
    }
}
