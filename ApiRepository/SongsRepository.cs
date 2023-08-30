using ApiDBAccess;
using ApiDTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository
{
    public class SongsRepository : ISongsRepository
    {
        IServer server { get; set; }
        public SongsRepository()
        {
            server = new Server();
        }
        public async Task<bool> Create(DtoSong songs)
        {
            return await server.Create(songs);
        }
        public async Task<List<DtoSong>> GetSongs()
        {
            return await server.GetSongs();
        }

        public async Task<DtoSong> GetSongs(int id)
        {
            return await server.GetSongs(id);
        }

        public async Task<bool> Update(DtoSong songs)
        {
            return await server.Update(songs);
        }
        public async Task<bool> Delete(int id)
        {
            return await server.Delete(id);
        }
    }
}
