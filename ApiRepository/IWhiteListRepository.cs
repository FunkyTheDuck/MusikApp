using ApiModels;

namespace ApiRepository
{
    public interface IWhiteListRepository
    {
        Task<bool> LikeSongAsync(WhiteList likedSong);
        Task<List<string>> GetUsersLikedSongs(int userId);
    }
}