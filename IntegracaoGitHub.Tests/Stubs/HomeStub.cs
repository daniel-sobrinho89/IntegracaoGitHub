using IntegracaoGitHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntegracaoGitHub.Tests.Stubs
{
    public class HomeStub
    {
        public static List<SetFavoriteRequest> SetFavoriteRequestList()
        {
            return new List<SetFavoriteRequest>()
                {
                    new SetFavoriteRequest(){
                        AvatarUrl = "https://myavatar1",
                        RepositoryId = "123",
                        RepositoryName = "Teste 1"
                    },
                    new SetFavoriteRequest(){
                        AvatarUrl = "https://myavatar2",
                        RepositoryId = "321",
                        RepositoryName = "Teste 2"
                    }
                };
        }
    }
}
