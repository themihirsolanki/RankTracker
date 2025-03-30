using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankTracker.Core.Services
{
    public interface IKeywordService
    {
        Task AddKeywordAsync(string keyword);
    }
}
