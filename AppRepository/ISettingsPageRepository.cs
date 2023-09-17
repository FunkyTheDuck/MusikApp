using AppModels;

namespace AppRepository
{
    public interface ISettingsPageRepository
    {
        Task<Settings> GetUsersSettingsAsync(int userId);
        Task<bool> UpdateSettingsAsync(Settings setting);
        Task<bool> CreateSettingsAsync(int userid);
    }
}