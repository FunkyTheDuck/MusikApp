using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class DisplayedSong
    {
        public string Id { get;set; }
        public string SongImage { get; set; }
        public string SongArtistImage { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public bool IsPlayable { get; set; }
        public string PreviewUrl { get; set; }

    }
}
