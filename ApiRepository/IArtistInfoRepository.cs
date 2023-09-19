namespace ApiRepository
{
    public interface IArtistInfoRepository
    {
        Task<List<int>> GetArtistLikeAndSkipByIdAsync(string Id);
    }
}