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
        public ObservableCollection<DisplayedSong> LikedSongsList { get; set; }
        ProfilPageRepository repo { get; set; }
        public ProfilViewModel(IProfilPageRepository repo)
        {
            this.repo = new ProfilPageRepository();
            Name = "Thomas Jasper Cat, Sr";
            skips = 69;
            isArtist = true;
            profilpicture = "profilbillede.jpg";
            LikedSongsList = new ObservableCollection<DisplayedSong>();
            GetAllLikedSong();
        }
        public async void GetAllLikedSong()
        {
            List<DisplayedSong> list = await repo.GetAllLikedSongs(Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")), 50);
            list.Reverse();
            foreach (DisplayedSong song in list)
            {
                LikedSongsList.Add(song);
            }
            likes = list.Count;
            OnPropChanged(nameof(likes));
            OnPropChanged(nameof(LikedSongsList));
        }
    }
}
