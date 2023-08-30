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
        public StartPageViewModel() 
        {
            PlaySound = new Command(PlaySongAsync);
        }
        public async void PlaySongAsync(object obj)
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ukulele_test.mp3"));
            audioPlayer.Play();
        }
    }
}
