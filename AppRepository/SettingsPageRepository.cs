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
    public class SettingsPageRepository
    {
        DBContext db { get;set; }
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
            if(dtoSettingns != null)
            {
                Settings settings = new Settings
                {
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
    }
}
