using SpotifyAPI.Web;

namespace AppRepository
{
    public interface IStartPageRepository
    {
        Task<FullTrack> GetSong(string songId);
        Task<bool> LikeSongAsync(int userId, int songId);
        Task<bool> SkipSongAsync(int userId, int songId);
        Task<string> GetArtistImageAsync(string id);
    }
}