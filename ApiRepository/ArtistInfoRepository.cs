using ApiDBAccess;
using ApiDTOModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class ArtistInfoRepository : IArtistInfoRepository
    {
        Database db;
        public ArtistInfoRepository()
        {
            db = new Database();
        }
        public async Task<List<int>> GetArtistLikeAndSkipByIdAsync(string Id)
        {
            DtoArtistInfo artistInfo;
            try
            {
                artistInfo = await db.ArtistInfo.FirstOrDefaultAsync(x => x.SpotifyId == Id);
            }
            catch
            {
                return new List<int> { 0,0 };
            }
            if (artistInfo != null)
            {
                List<int> LikeAndSkip = new List<int>
                {
                    artistInfo.AmountOfSongsLiked,
                    artistInfo.AmountOfSongSkipped
                };
                return LikeAndSkip;
            }
            return new List<int> { 0, 0 };
        }
    }
}
