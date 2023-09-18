using AppDBAccess;
using AppDTOModels;
using AppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class SettingsPageRepository : ISettingsPageRepository
    {
        DBContext db { get; set; }
        public SettingsPageRepository()
        {
            db = new DBContext();
        }
        public async Task<Settings> GetUsersSettingsAsync(int userId)
        {
            DtoSettings dtoSettingns;
            try
            {
                dtoSettingns = await db.GetUsersSettingsAsync(userId);
            }
            catch
            {
                return null;
            }
            if (dtoSettingns != null)
            {
                Settings settings = new Settings
                {
                    Id = dtoSettingns.Id,
                    UserId = dtoSettingns.UserId,
                    ChangeGenre = dtoSettingns.ChangeGenre,
                    HowNewTheMusicIs = dtoSettingns.HowNewTheMusicIs,
                    NotificationsAmount = dtoSettingns.NotificationsAmount,
                    Popularity = dtoSettingns.Popularity,
                    Energy = dtoSettingns.Energy,
                    Danceability = dtoSettingns.Danceability
                };
                return settings;
            }
            return null;
        }
        public async Task<bool> UpdateSettingsAsync(Settings setting)
        {
            if (setting != null)
            {
                DtoSettings dtoSetting = new DtoSettings
                {
                    Id = setting.Id,
                    UserId = setting.UserId,
                    ChangeGenre = setting.ChangeGenre,
                    HowNewTheMusicIs = setting.HowNewTheMusicIs,
                    NotificationsAmount = setting.NotificationsAmount,
                    Popularity = setting.Popularity,
                    Energy = setting.Energy,
                    Danceability = setting.Danceability
                };
                return await db.UpdateSettingsAsync(dtoSetting);
            }
            return false;
        }
        public async Task<bool> CreateSettingsAsync(int userid)
        {
            DtoSettings dtoSettings = new DtoSettings
            {
                UserId = userid,
            };
            return await db.CreateSettingsAsync(dtoSettings);
        }
    }
}
