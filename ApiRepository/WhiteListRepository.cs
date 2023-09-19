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
        private async Task<bool> AddOneLikeToArtist(string ArtistId)
        {
            DtoArtistInfo? artistLikes;
            try
            {
                artistLikes = await db.ArtistInfo.FirstOrDefaultAsync(x => x.SpotifyId == ArtistId);
            }
            catch
            {
                return false;
            }
            if(artistLikes != null)
            {
                artistLikes.AmountOfSongsLiked += 1;
                db.ArtistInfo.Update(artistLikes);
            }
            else
            {
                DtoArtistInfo dtoArtistInfo = new DtoArtistInfo
                {
                    SpotifyId = ArtistId,
                    AmountOfSongSkipped = 0,
                    AmountOfSongsLiked = 1,
                };
                await db.ArtistInfo.AddAsync(dtoArtistInfo);
            }
            int checkIfSucces = 0;
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
            return false;
        }
        public async Task<bool> LikeSongAsync(WhiteList likedSong)
        {
            DtoWhiteList dtoLikedSong = new DtoWhiteList
            {
                UserID = likedSong.UserID,
                SongID = likedSong.SongID,
                SongArtistId = likedSong.SongArtistId,
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
            
            if(await AddOneLikeToArtist(dtoLikedSong.SongArtistId))
            {

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
