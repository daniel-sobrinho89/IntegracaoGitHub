using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoGitHub.Models.Entities
{
    [Table(nameof(Favorite))]
    public class Favorite
    {
        public int Id { get; set; }
        [Key]
        public string RepositoryId { get; set; }
        public string AvatarUrl { get; set; }
        public string RepositoryName { get; set; }
    }
}
