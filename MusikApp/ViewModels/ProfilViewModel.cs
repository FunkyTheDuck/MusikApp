using AppModels;
using AppRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusikApp.ViewModels
{
    public class ProfilViewModel : BaseViewModels
    {
        public string Name { get; set; }
        public int likes { get; set; }
        public int skips { get; set; }
        public bool isArtist { get; set; }
        public int likesArtist { get; set; }
        public int skipsArtist { get; set; }
        public string profilpicture {  get; set; }
        public List<DisplayedSong> LikedSongsList { get; set; }
        ProfilPageRepository repo { get; set; }
        public ProfilViewModel(IProfilPageRepository repo)
        {
            this.repo = new ProfilPageRepository();
            Name = "Thomas Jasper Cat, Sr.";
            likes = 420;
            skips = 69;
            isArtist = false;
            profilpicture = "profilbillede.jpg";
            GetAllLikedSong();
        }
        public async void GetAllLikedSong()
        {
            LikedSongsList = await repo.GetAllLikedSongs(1, 10);
            OnPropChanged(nameof(LikedSongsList));
        }
    }
}
