using AppModels;

namespace AppRepository
{
    public interface IProfilPageRepository
    {
        Task<List<DisplayedSong>> GetAllLikedSongs(int userId, int startPos);
    }
}