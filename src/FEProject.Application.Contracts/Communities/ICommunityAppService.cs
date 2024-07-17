using System.Threading.Tasks;

namespace FEProject.Communities
{
    public interface ICommunityAppService
    {
        Task CreateAsync(CreateCommunityDto input);
    }
}
