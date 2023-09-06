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
        //public List<Song> songs { get; set; }
        ObservableCollection<Song> songs = new ObservableCollection<Song>();
        public ObservableCollection<Song> Songs { get; set; }
        public ProfilViewModel() 
        {
            Name = "Thomas Jasper Cat, Sr.";
            likes = 420;
            skips = 69;
            isArtist = true;
            profilpicture = "profilbillede.jpg";
            songs.Add(new Song { Id = 1, ArtistId = 1, Artist = new Artist { User = new User { Name = "Test1 med meget langt navn", ProfilPicture = "profilbillede.jpg" } }, Name = "sang1 med langt navn", AlbumImage = "profilbillede.jpg" });
            songs.Add(new Song { Id = 2, ArtistId = 2, Artist = new Artist { User = new User { Name = "Test2", ProfilPicture = "profilbillede.jpg" } }, Name = "sang2", AlbumImage = "profilbillede.jpg" });
            songs.Add(new Song { Id = 3, ArtistId = 3, Artist = new Artist { User = new User { Name = "Test3", ProfilPicture = "profilbillede.jpg" } }, Name = "sang3", AlbumImage = "profilbillede.jpg" });
            songs.Add(new Song { Id = 4, ArtistId = 4, Artist = new Artist { User = new User { Name = "Test4", ProfilPicture = "profilbillede.jpg" } }, Name = "sang4", AlbumImage = "profilbillede.jpg" });
            songs.Add(new Song { Id = 5, ArtistId = 5, Artist = new Artist { User = new User { Name = "Test5", ProfilPicture = "profilbillede.jpg" } }, Name = "sang5", AlbumImage = "profilbillede.jpg" });
            Songs = songs;
        }
    }
}
