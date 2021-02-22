using IntegracaoGitHub.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace IntegracaoGitHub.Models
{
    public class SetFavoriteRequest
    {
        /// <param name="AvatarUrl">Url do Avatar no GitHub</param>
        public string AvatarUrl { get; set; }

        /// <param name="RepositoryId">Id do repositório no GitHub</param>
        [Required]
        [MinLength(1)]
        public string RepositoryId { get; set; }

        /// <param name="RepositoryName">Nome do repositório no GitHub</param>
        [Required]
        [MinLength(5)]
        public string RepositoryName { get; set; }
    }

    public static class SetFavoriteRequestExtension
    {
        public static Favorite ToFavorite(this SetFavoriteRequest model)
        {
            var favorito = new Favorite()
            {
                AvatarUrl = model.AvatarUrl,
                RepositoryId = model.RepositoryId,
                RepositoryName = model.RepositoryName
            };

            return favorito;
        }
    }
}