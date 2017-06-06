using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IProfileService
    {
        ProfileEntity GetProfileEntity(int id);

        void CreateProfile(ProfileEntity profile);
        void DeleteProfile(ProfileEntity profile);
        void UpdateProfile(ProfileEntity profile);
    }
}
