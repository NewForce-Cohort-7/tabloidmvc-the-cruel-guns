using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface IUserProfileRepository
    {
        List<UserProfile> GetAllUserProfiles();
        UserProfile GetByEmail(string email);
    }
}