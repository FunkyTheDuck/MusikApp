﻿using MusikApp.Views;
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
        public ICommand CreateUserCommand { get; set; }
        public ICommand SpotifyUserCommand { get; set; }
        public ICommand AppleUserCommand { get; set; }
        public ICommand SoundCloudUserCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public LoginPageViewModel()
        {
            CreateUserCommand = new Command(UserTapped);
            SpotifyUserCommand = new Command(SpotifyTapped);
            AppleUserCommand = new Command(AppleTapped);
            SoundCloudUserCommand = new Command(SoundCloudTapped);
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked()
        {
            if (Username == "Admin" && Password == "Admin")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new StartPage());
            }
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

        public async void UserTapped()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CreateUserPage());
        }
        
    }
}
