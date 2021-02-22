using IntegracaoGitHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegracaoGitHub.Services.Interface
{
    public interface IHomeService
    {
        Task<int> SetFavoriteAsync(SetFavoriteRequest setFavoriteRequest);

        Task<IEnumerable<SetFavoriteRequest>> GetFavoritesAsync();
    }
}
