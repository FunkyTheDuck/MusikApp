using ApiModels;

namespace ApiRepository
{
    public interface IBlackListRepository
    {
        Task<bool> SkipSongAsync(BlackList skippedSong);
    }
}