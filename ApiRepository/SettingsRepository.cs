using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class SettingsRepository
    {
        Database db { get; set; }
        public SettingsRepository()
        {
            db = new Database();
        }
        public async Task<Settings> GetUsersSettingsAsync(int userId)
        {
            DtoSettings? dtoSettings;
            try
            {
                dtoSettings = await db.Settings.FirstOrDefaultAsync(x => x.UserId == userId);
            }
            catch
            {
                return null;
            }
            if(dtoSettings != null)
            {
                Settings settings = new Settings
                {
                    UserId = dtoSettings.UserId,
                    ChangeGenre = dtoSettings.ChangeGenre,
                    HowNewTheMusicIs = dtoSettings.HowNewTheMusicIs,
                    NotificationsAmount = dtoSettings.NotificationsAmount,
                    Popularity = dtoSettings.Popularity,
                    Energy = dtoSettings.Energy,
                    Danceability = dtoSettings.Danceability
                };
                return settings;
            }
            return null;
        }
    }
}