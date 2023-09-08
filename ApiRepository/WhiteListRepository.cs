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
    public class WhiteListRepository : IWhiteListRepository
    {
        Database db;
        public WhiteListRepository()
        {
            db = new Database();
        }
        public async Task<bool> LikeSongAsync(WhiteList likedSong)
        {
            DtoWhiteList dtoLikedSong = new DtoWhiteList
            {
                UserID = likedSong.UserID,
                SongID = likedSong.SongID,
            };
            try
            {
                var temp = db.WhiteLists.Add(dtoLikedSong);
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
