using AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikApp.ViewModels
{
    public class ProfilViewModel
    {
        public string Name { get; set; }
        public int likes { get; set; }
        public int skips { get; set; }
        public bool isArtist { get; set; }
        public int likesArtist { get; set; }
        public int skipsArtist { get; set; }
        public string profilpicture {  get; set; }
        public List<string> SongImage { get; set; }
        public List<string> SongArtistImage { get; set; }
        public List<string> SongName { get; set; }
        public List<string> AlbumName { get; set; }
        public List<string> ArtistName { get; set; }
        public ProfilViewModel() 
        {
            Name = "Thomas Jasper Cat, Sr.";
            likes = 420;
            skips = 69;
            isArtist = true;
            profilpicture = "profilbillede.jpg";
        }
    }
}
