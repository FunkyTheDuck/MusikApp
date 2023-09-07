using AppDBAccess;
using AppDTOModels;
using AppModels;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class StartPageRepository : IStartPageRepository
    {
        DBContext db;
        SpotifyDBContext spotifyDB;
        public StartPageRepository()
        {
            db = new DBContext();
            spotifyDB = new SpotifyDBContext();
        }
        public async Task<FullTrack> GetSong(string songId)
        {
            return await spotifyDB.GetNewSongAsync(songId);
        }
        public async Task<bool> LikeSongAsync(WhiteList whiteList)
        {
            DtoWhiteList dtoWhiteList = new DtoWhiteList
            {
                UserID = whiteList.UserID,
                SongID = whiteList.SongID,
            };

            try
            {
                return await db.LikeSongAsync(dtoWhiteList);
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SkipSongAsync(BlackList blackList)
        {
            DtoBlackList dtoBlackList = new DtoBlackList
            {
                UserID = blackList.UserID,
                SongID = blackList.SongID,
            };
            try
            {
                return await db.SkipSongAsync(dtoBlackList);
            }
            catch
            {
                return false;
            }
        }
        public async Task<string> GetArtistImageAsync(string id)
        {
            return await spotifyDB.GetArtistImageAsync(id);
        }
        public async Task<List<FullTrack>> GetListOfSongs(List<string> songIds)
        {
            try
            {
                return await spotifyDB.GetListOfSongs(songIds);
            }
            catch
            {
                return null;
            }
        }
    }
}
