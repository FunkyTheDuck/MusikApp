using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public interface IArtistPaymentRepository
    {
        Task<List<DtoArtistPayment>> GetArtistPayments();
        Task<DtoArtistPayment> GetArtistPayments(int id);
        Task<bool> Create(DtoArtistPayment artistPayments);
        Task<bool> Update(DtoArtistPayment artistPayments);
        Task<bool> Delete(int id);
    }
}
