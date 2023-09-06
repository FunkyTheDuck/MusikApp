using SpotifyAPI.Web;

namespace AppRepository
{
    public interface IStartPageRepository
    {
        Task<FullTrack> GetSong(string songId);
        Task<bool> LikeSongAsync(int userId, string songId);
        Task<bool> SkipSongAsync(int userId, string songId);
        Task<string> GetArtistImageAsync(string id);
    }
}