using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoArtist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        public List<string>? HighlightSong { get; set; }
        public List<DtoSong> Songs { get; set; }
        public DtoArtistPayment ArtistPayment { get; set; }
    }
}
