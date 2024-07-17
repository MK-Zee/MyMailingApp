using FEProject.Communities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FEProject.Services
{
    public class CommunityAppService : ApplicationService, ICommunityAppService
    {
        private readonly IRepository<Community, Guid> _communityRepository;

        public CommunityAppService(IRepository<Community, Guid> communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task CreateAsync(CreateCommunityDto dto)
        {

            try
            {
                var community = new Community
                {
                    CommunityName = dto.CommunityName,
                    CommunityName_Ar = dto.CommunityName_Ar,
                    CreatedBy = dto.CreatedBy,
                    MainBranch = dto.MainBranch
                };

                var r = await _communityRepository.InsertAsync(community);
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }

        }
    }
}
