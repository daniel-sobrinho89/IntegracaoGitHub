using IntegracaoGitHub.Infrastructure.Repository.Interface;
using IntegracaoGitHub.Models;
using IntegracaoGitHub.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegracaoGitHub.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<int> SetFavoriteAsync(SetFavoriteRequest setFavoriteRequest)
        {
            return await _homeRepository.SetFavoriteAsync(setFavoriteRequest);
        }

        public async Task<IEnumerable<SetFavoriteRequest>> GetFavoritesAsync()
        {
            return await _homeRepository.GetFavoritesAsync();
        }
    }
}
