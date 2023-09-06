using ApiModels;

namespace ApiRepository
{
    public interface IWhiteListRepository
    {
        Task<bool> LikeSongAsync(WhiteList likedSong);
    }
}