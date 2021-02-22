using IntegracaoGitHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegracaoGitHub.Infrastructure.Repository.Interface
{
    public interface IHomeRepository
    {
        Task<int> SetFavoriteAsync(SetFavoriteRequest setFavoriteRequest);

        Task<List<SetFavoriteRequest>> GetFavoritesAsync();
    }
}
