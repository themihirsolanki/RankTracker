using RankTracker.Core.Entities;
using RankTracker.Core.Repositories;

namespace RankTracker.Core.Services;

public class KeywordService : IKeywordService
{
    private readonly IKeywordRepository keywordRepository;

    public KeywordService(IKeywordRepository keywordRepository)
    {
        this.keywordRepository = keywordRepository;
    }

    public async Task AddKeywordAsync(string keyword)
    {
        await keywordRepository.AddAsync(new Keyword { Text = keyword });

    }
}
