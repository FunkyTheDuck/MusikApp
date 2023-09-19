using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoArtistInfo
    {
        public int Id { get; set; }
        public string SpotifyId { get; set; }
        public int AmountOfSongsLiked { get; set; }
        public int AmountOfSongSkipped { get; set; }
    }
}