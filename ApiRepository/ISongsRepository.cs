using ApiModels;

namespace ApiRepository
{
    public interface ISongsRepository
    {
        Task<bool> Create(Song Song);
        Task<bool> Delete(int id);
        Task<List<Song>> GetSongs();
        Task<Song> GetSongs(int id);
        Task<bool> Update(Song song);
    }
}