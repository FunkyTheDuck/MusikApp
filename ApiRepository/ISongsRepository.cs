using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public interface ISongsRepository
    {
        Task<List<DtoSong>> GetSongs();
        Task<DtoSong> GetSongs(int id);
        Task<bool> Create(DtoSong songs);
        Task<bool> Update(DtoSong songs); 
        Task<bool> Delete(int id);
    }
}
