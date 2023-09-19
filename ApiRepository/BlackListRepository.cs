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
    public class BlackListRepository : IBlackListRepository
    {
        Database db;
        public BlackListRepository()
        {
            db = new Database();
        }
        private async Task<bool> AddOneSkipToArtist(string ArtistId)
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
            if (artistLikes != null)
            {
                artistLikes.AmountOfSongSkipped += 1;
                db.ArtistInfo.Update(artistLikes);
            }
            else
            {
                DtoArtistInfo dtoArtistInfo = new DtoArtistInfo
                {
                    Id = 0,
                    SpotifyId = ArtistId,
                    AmountOfSongSkipped = 1,
                    AmountOfSongsLiked = 0,
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
            if (checkIfSucces > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> SkipSongAsync(BlackList skippedSong)
        {
            DtoBlackList dtoSkippedSong = new DtoBlackList
            {
                UserID = skippedSong.UserID,
                SongID = skippedSong.SongID,
                SongArtistId = skippedSong.SongArtistId,
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
            if(await AddOneSkipToArtist(dtoSkippedSong.SongArtistId))
            {

            }
            return true;
        }
    }
}
