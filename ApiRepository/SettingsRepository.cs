using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                    Id = dtoSettings.Id,
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

        public async Task<bool> UpdateUserSettingsAsync(Settings setting)
        {
            if(setting != null)
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
                try
                {
                    db.Settings.Update(dtoSetting);
                }
                catch
                {
                    return false;
                }
                int checkIfSucces;
                try
                {
                    checkIfSucces = await db.SaveChangesAsync();
                }
                catch
                {
                    return false;
                }
                if(checkIfSucces > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> CreateUserSettingsAsync(Settings setting)
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
                try
                {
                    await db.Settings.AddAsync(dtoSetting);
                }
                catch
                {
                    return false;
                }
                int checkIfSucces;
                try
                {
                    checkIfSucces = await db.SaveChangesAsync();
                }
                catch
                {
                    return false;
                }
                if (checkIfSucces > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}