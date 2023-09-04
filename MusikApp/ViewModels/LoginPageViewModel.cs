using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModels
    {
        public ICommand SpotifyUserCommand { get; set; }
        public ICommand AppleUserCommand { get; set; }
        public ICommand SoundCloudUserCommand { get; set; }


        public LoginPageViewModel()
        {
            SpotifyUserCommand = new Command(SpotifyTapped);
            AppleUserCommand = new Command(AppleTapped);
            SoundCloudUserCommand = new Command(SoundCloudTapped);
        }

        public async void SpotifyTapped()
        {
            await (Application.Current.MainPage).DisplayAlert("Information", "Sign in with Spotify is comming soon", "OK");
        }

        public async void AppleTapped()
        {
            await (Application.Current.MainPage).DisplayAlert("Warning", "Sign in with Apple is comming soon", "OK");
        }

        public async void SoundCloudTapped()
        {
            await (Application.Current.MainPage).DisplayAlert("Warning", "Sign in with Sound Cloud is comming soon", "OK");
        }
    }
}
