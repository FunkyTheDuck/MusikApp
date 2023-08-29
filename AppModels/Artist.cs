using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class Artist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<string>? HighlightSong { get; set; }
        public List<Song> Songs { get; set; }
        public ArtistPayment ArtistPayment { get; set; }
    }
}
