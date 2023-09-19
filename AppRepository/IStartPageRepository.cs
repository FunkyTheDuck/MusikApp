using AppModels;
using SpotifyAPI.Web;

namespace AppRepository
{
    public interface IStartPageRepository
    {
        Task<FullTrack> GetSong(string songId);
        Task<bool> LikeSongAsync(WhiteList whiteList);
        Task<bool> SkipSongAsync(BlackList blackList);
        Task<string> GetArtistImageAsync(string id);
        Task<DisplayedArtist> GetArtistAsync(string id);
        Task<List<FullTrack>> GetListOfSongs(List<string> songIds);
        Task<List<DisplayedSong>> GetListOfRecommendation(int id, int amount);
    }
}