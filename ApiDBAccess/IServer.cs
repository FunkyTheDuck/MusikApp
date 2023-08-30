using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDBAccess
{
    public interface IServer
    {
        List<DtoArtist> Artists { get; set; }
        List<DtoArtistPayment> ArtistPayments { get; set; }
        List<DtoBlackList> Blacklists { get; set; }
        List<DtoPremium> Premiums { get; set; }
        List<DtoSettings> Settings { get; set; }
        List<DtoSong> Songs { get; set; }
        List<DtoUser> Users { get; set; }
        List<DtoWhiteList> Whitelists { get; set; }

        Task<List<DtoArtistPayment>> GetArtistPayments();
        Task<DtoArtistPayment> GetArtistPayments(int id);
        Task<bool> Create(DtoArtistPayment artistPayments);
        Task<bool> Update(DtoArtistPayment artistPayments); 
        Task<List<DtoSong>> GetSongs();
        Task<DtoSong> GetSongs(int id);
        Task<bool> Create(DtoSong songs);
        Task<bool> Update(DtoSong songs);
        Task<List<DtoUser>> GetUsers();
        Task<DtoUser> GetUsers(int id);
        Task<bool> Create(DtoUser user);
        Task<bool> Update(DtoUser user);
        Task<bool> Delete(int id);
    }
}
