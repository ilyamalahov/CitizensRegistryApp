using CitizensRegistryApp.Core.Paging;
using CitizensRegistryApp.Core.Profiles.Dto;
using System.Threading.Tasks;

namespace CitizensRegistryApp.Core.Profiles
{
    public interface IProfilesRepository
    {
        Task<PagingModel<ProfileDto>> GetProfiles(ProfileFilter filter, int page, int pageSize);
    }
}
