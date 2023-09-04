using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class StartPageViewModel : BaseViewModels
    {
        public ICommand PlaySound { get; set; }
        public string PausePlayBtnSource { get; set; }
        public string SongImage { get; set; }
        public string SongArtistImage { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public StartPageViewModel() 
        {
            PausePlayBtnSource = "play_icon.png";
            SongImage = "test_song_image.jpg";
            SongArtistImage = "test_song_image.jpg";
            SongName = "Going Fast On 3 Wheels";
            AlbumName = "Gang Gang";
            ArtistName = "Marcus Und Simon";
            OnPropChanged(nameof(PausePlayBtnSource));
            OnPropChanged(nameof(SongImage));
            OnPropChanged(nameof(SongArtistImage));
            OnPropChanged(nameof(SongName));
            OnPropChanged(nameof(AlbumName));
            OnPropChanged(nameof(ArtistName));
            PlaySound = new Command(PlaySongAsync);
        }
        public async void PlaySongAsync(object obj)
        {
            AudioPlayer audioPlayer = (AudioPlayer)AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ukulele_test.mp3"));
            audioPlayer.Play();
        }
    }
}
