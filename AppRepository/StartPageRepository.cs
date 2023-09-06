using AppDBAccess;
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
        public async Task<bool> LikeSongAsync(int userId, string songId)
        {
            return true;
        }
        public async Task<bool> SkipSongAsync(int userId, string songId)
        {
            return true;
        }
        public async Task<string> GetArtistImageAsync(string id)
        {
            return await spotifyDB.GetArtistImageAsync(id);
        }
    }
}
