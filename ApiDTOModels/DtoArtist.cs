using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoArtist
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DtoUser user { get; set; }
        public List<string>? highlightSong { get; set; }
        public List<DtoSong> songs { get; set; }
        public DtoArtistPayment artistPayment { get; set; }
    }
}
