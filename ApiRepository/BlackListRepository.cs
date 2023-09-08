using ApiDBAccess;
using ApiDTOModels;
using ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class BlackListRepository : IBlackListRepository
    {
        Database db;
        public BlackListRepository()
        {
            db = new Database();
        }
        public async Task<bool> SkipSongAsync(BlackList skippedSong)
        {
            DtoBlackList dtoSkippedSong = new DtoBlackList
            {
                UserID = skippedSong.UserID,
                SongID = skippedSong.SongID,
            };
            try
            {
                db.BlackLists.Add(dtoSkippedSong);
            }
            catch
            {
                return false;
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
