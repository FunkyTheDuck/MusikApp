using ApiModels;

namespace ApiRepository
{
    public interface IArtistPaymentRepository
    {
        Task<bool> Create(ArtistPayment artistPayment);
        Task<bool> Delete(int id);
        Task<List<ArtistPayment>> GetArtistPayments();
        Task<ArtistPayment> GetArtistPayments(int id);
        Task<bool> Update(ArtistPayment artistPayment);
    }
}