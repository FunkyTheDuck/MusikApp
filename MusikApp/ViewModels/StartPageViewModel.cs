using AppRepository;
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
        StartPageRepository repo { get; set; }
        public ICommand PlayPauseSound { get; set; }
        public ICommand SkipSong { get; set; }
        public ICommand LikeSong { get; set; }
        public string PlayPauseBtnSource { get; set; }
        public string SongImage { get; set; }
        public string SongArtistImage { get; set; }
        public string SongName { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }

        AudioPlayer currentSong = null;
        public StartPageViewModel()
        {
            repo = new StartPageRepository();
            GetAnotherSong();
            PlayPauseBtnSource = "play_icon.png";
            SongImage = "test_song_image.jpg";
            SongArtistImage = "test_song_image.jpg";
            SongName = "Going Fast On 3 Wheels";
            AlbumName = "Gang Gang";
            ArtistName = "Marcus Und Simon";
            OnPropChanged(nameof(PlayPauseBtnSource));
            OnPropChanged(nameof(SongImage));
            OnPropChanged(nameof(SongArtistImage));
            OnPropChanged(nameof(SongName));
            OnPropChanged(nameof(AlbumName));
            OnPropChanged(nameof(ArtistName));
            PlayPauseSound = new Command(PlayPauseSongAsync);
            SkipSong = new Command(SkipCurrentSongAsync);
            LikeSong = new Command(LikeCurrentSongAsync);
        }
        public async void GetAnotherSong()
        {
            currentSong = (AudioPlayer)AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ukulele_test.mp3"));

        }
        public async void PlayPauseSongAsync(object obj)
        {
            //tjek om sangen bliver afspillet
            if(PlayPauseBtnSource == "play_icon.png")
            {
                PlayPauseBtnSource = "pause_icon.png";
                currentSong.Play();
            }
            else
            {
                PlayPauseBtnSource = "play_icon.png";
                currentSong.Pause();
            }
            OnPropChanged(nameof(PlayPauseBtnSource));
        }
        public async void LikeCurrentSongAsync(object obj)
        {
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.LikeSongAsync(0,5326245);
            }
            catch
            {
                checkIfSucces = false;
            }
            if (checkIfSucces) 
            {
                //fortæl brugeren det gik godt 
            }
            else
            {
                //fortæl brugeren det gik lort
            }
        }
        public async void SkipCurrentSongAsync(object obj)
        {
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.SkipSongAsync(0, 726265785);
            }
            catch
            {
                checkIfSucces = false;
            }
            if (checkIfSucces)
            {
                //fortæl brugeren det gik godt 
            }
            else
            {
                //fortæl brugeren det gik lort
            }
        }
        public async void GoToProfilPageAsync(object obj)
        {

        }
        public async void GoToSettingsPageAsync(object obj)
        {

        }
    }
}