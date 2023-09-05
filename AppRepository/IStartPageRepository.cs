namespace AppRepository
{
    public interface IStartPageRepository
    {
        Task<bool> LikeSongAsync(int userId, int songId);
        Task<bool> SkipSongAsync(int userId, int songId);
    }
}