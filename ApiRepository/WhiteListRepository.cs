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
                db.WhiteLists.Add(dtoLikedSong);
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
        public async Task<List<string>> GetUsersLikedSongs(int userId)
        {
            List<DtoWhiteList> likedSongs;
            try
            {
                likedSongs = await db.WhiteLists.Where(x => x.UserID == userId).ToListAsync();
            }
            catch
            {
                return new List<string>();
            }
            if(likedSongs.Count > 0)
            {
                List<string> likedSongsId = new List<string>();
                foreach(DtoWhiteList songId in likedSongs)
                {
                    likedSongsId.Add(songId.SongID);
                }
                return likedSongsId;
            }
            return new List<string>();
        }
    }
}
