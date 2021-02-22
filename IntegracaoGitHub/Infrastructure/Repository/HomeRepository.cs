using IntegracaoGitHub.Infrastructure.Context;
using IntegracaoGitHub.Infrastructure.Repository.Interface;
using IntegracaoGitHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoGitHub.Infrastructure.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeContext _homeContext;

        public HomeRepository(HomeContext homeContext)
        {
            _homeContext = homeContext;
        }
        public async Task<int> SetFavoriteAsync(SetFavoriteRequest setFavoriteRequest)
        {
            try
            {
                await _homeContext.Favorites.AddAsync(setFavoriteRequest.ToFavorite());

                return await _homeContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível realizar a sua operação neste momento, por favor vefifique se este favorito já está salvo.");
            }
        }
        
        public async Task<List<SetFavoriteRequest>> GetFavoritesAsync()
        {
            try
            {
                return await _homeContext
                    .Favorites
                    .Select(p =>
                        new SetFavoriteRequest()
                        {
                            AvatarUrl = p.AvatarUrl,
                            RepositoryId = p.RepositoryId,
                            RepositoryName = p.RepositoryName
                        })
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível realizar a sua operação neste momento.");
            }
        }
    }
}
