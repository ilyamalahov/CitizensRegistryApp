using CitizensRegistryApp.Core.Paging;
using CitizensRegistryApp.Core.Profiles;
using CitizensRegistryApp.Core.Profiles.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CitizensRegistryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfilesRepository profilesRepository;

        public ProfilesController(IProfilesRepository profilesRepository)
        {
            this.profilesRepository = profilesRepository;
        }

        [HttpGet]
        public async Task<PagingModel<ProfileDto>> GetAll(int page, int pageSize, string filter = null)
        {
            try
            {
                ProfileFilter profileFilter = null;

                if (filter != null)
                {
                    profileFilter = JsonSerializer.Deserialize<ProfileFilter>(filter);
                }

                return await profilesRepository.GetProfiles(profileFilter, page, pageSize);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}