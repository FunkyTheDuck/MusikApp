using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Artist
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public string? highlightSong { get; set; }
        public List<Song> songs { get; set; }
        public ArtistPayment artistPayment { get; set; }
    }
}
