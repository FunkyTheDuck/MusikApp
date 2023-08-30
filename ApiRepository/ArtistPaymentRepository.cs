using ApiDBAccess;
using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class ArtistPaymentRepository : IArtistPaymentRepository
    {
        IServer server { get; set; }
        public ArtistPaymentRepository()
        {
            server = new Server();
        }

        public async Task<bool> Create(DtoArtistPayment artistPayments)
        {
            return await server.Create(artistPayments);
        }
        public async Task<List<DtoArtistPayment>> GetArtistPayments()
        {
            return await server.GetArtistPayments();
        }

        public async Task<DtoArtistPayment> GetArtistPayments(int id)
        {
            return await server.GetArtistPayments(id);
        }
        public async Task<bool> Update(DtoArtistPayment artistPayments)
        {
            return await server.Update(artistPayments);
        }
        public async Task<bool> Delete(int id)
        {
            return await server.Delete(id);
        }
    }
}
