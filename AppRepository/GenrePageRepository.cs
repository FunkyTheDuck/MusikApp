using AppDBAccess;
using AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class GenrePageRepository
    {
        SpotifyDBContext spotifydb;

        public GenrePageRepository()
        {
            spotifydb = new SpotifyDBContext();
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            return await spotifydb.GetAllGenresAsync();
        }


    }


}
