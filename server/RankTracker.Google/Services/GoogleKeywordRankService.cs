using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;
using RankTracker.Core.Services;

namespace RankTracker.Google.Services;
public class GoogleKeywordRankService : IKeywordRankService
{
    private readonly IKeywordRepository keywordRepository;
    private readonly GoogleSerpScrapingService googleSerpScrapingService;
    private readonly ISearchEngineRepository searchEngineRepository;
    private readonly IKeywordRankRepository keywordRankRepository;
    private readonly string searchEngine = "Google";

    public GoogleKeywordRankService(IKeywordRepository keywordRepository,
        GoogleSerpScrapingService googleSerpScrapingService,
        ISearchEngineRepository searchEngineRepository,
        IKeywordRankRepository keywordRankRepository)
    {
        this.keywordRepository = keywordRepository;
        this.searchEngineRepository = searchEngineRepository;
        this.keywordRankRepository = keywordRankRepository;
        this.googleSerpScrapingService = googleSerpScrapingService;
    }

    public async Task CheckKeywordRank(string domain, int keywordId)
    {
        var keyword = await keywordRepository.GetAsync(keywordId);
        var links = await googleSerpScrapingService.ExtractLinks(keyword.Text);
        var index = FindFirstPartialMatch(links.ToArray(), domain);

        int rank = index >= 0 ? rank = index + 1 : 0;

        keyword.GoogleRank = rank;
        keyword.DateModified = DateTime.UtcNow;
        await keywordRepository.UpdateAsync(keyword);

        await AddKeywordRankHistory(keyword, rank);
    }

    private async Task AddKeywordRankHistory(Keyword keyword, int rank)
    {
        var searchEngine = await searchEngineRepository.GetSearchEngineByName(this.searchEngine.ToLowerInvariant());

        searchEngine = await EnsureSearchEngine(searchEngine);

        var keywordRankHistory = new KeywordRank
        {
            KeywordId = keyword.Id,
            Rank = rank,
            SearchEngineId = searchEngine.Id,
            DateCreated = DateTime.Now
        };

        await keywordRankRepository.AddAsync(keywordRankHistory);
    }

    private async Task<SearchEngine> EnsureSearchEngine(SearchEngine searchEngine)
    {
        if (searchEngine == null)
        {
            searchEngine = new SearchEngine
            {
                Name = this.searchEngine,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await searchEngineRepository.AddAsync(searchEngine);
        }

        return searchEngine;
    }

    private static int FindFirstPartialMatch(string[] array, string keyword)
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
