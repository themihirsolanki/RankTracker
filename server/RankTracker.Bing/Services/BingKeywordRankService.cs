﻿using RankTracker.Core.Repositories;
using RankTracker.Core.Services;

namespace RankTracker.Bing.Services;

public class BingKeywordRankService : IKeywordRankService
{
    private readonly IKeywordRepository keywordRepository;
    private readonly BingSerpScrapingService bingSerpScrapingService;

    public BingKeywordRankService(IKeywordRepository keywordRepository,
        BingSerpScrapingService bingSerpScrapingService)
    {
        this.keywordRepository = keywordRepository;
        this.bingSerpScrapingService = bingSerpScrapingService;
    }

    public async Task CheckKeywordRank(string domain, int keywordId)
    {
        var keyword = await keywordRepository.GetAsync(keywordId);
        var links = await bingSerpScrapingService.ExtractLinks(keyword.Text);
        var index = FindFirstPartialMatch(links.ToArray(), domain);

        if (index >= 0)
        {
            keyword.Rank = index + 1;
        }
        else { 
            keyword.Rank = 0; // not found in current result set
        }

        await keywordRepository.UpdateAsync(keyword);
    }

    public static int FindFirstPartialMatch(string[] array, string keyword)
    {
        if (array == null || string.IsNullOrEmpty(keyword))
        {
            return -1; 
        }

        var match = array
            .Select((item, index) => new { item, index })
            .FirstOrDefault(x => x.item != null && x.item.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        return match != null ? match.index : -1;
    }
}
