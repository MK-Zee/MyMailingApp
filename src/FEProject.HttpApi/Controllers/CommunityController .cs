using FEProject.Communities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FEProject.Controllers
{
    [ApiController]
    [Route("api/community")]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityAppService _communityAppService;
        public CommunityController(ICommunityAppService communityAppService)
        {
            _communityAppService = communityAppService;
        }
        [HttpPost("createCommunity")]
        public async Task<IActionResult> CreateAsync(CreateCommunityDto input)
        {
            await _communityAppService.CreateAsync(input);
            return Ok("Community Created Successdully");
        }

    }
}
