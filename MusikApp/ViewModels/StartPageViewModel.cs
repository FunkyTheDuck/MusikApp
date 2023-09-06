﻿using AppModels;
using AppRepository;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        FullTrack currentSong { get; set; }
        public MediaElement AudioDisplay { get; set; }
       
        public StartPageViewModel()
        {
            AudioDisplay = new MediaElement
            {
                Volume = 0.02,
                ShouldAutoPlay = false,
            };
            repo = new StartPageRepository();
            GetAnotherSong("6uu74oWxGhnyNs3QvoeOcP");
            PlayPauseBtnSource = "play_icon.png";
            OnPropChanged(nameof(PlayPauseBtnSource));
            PlayPauseSound = new Command(PlayPauseSongAsync);
            SkipSong = new Command(SkipCurrentSongAsync);
            LikeSong = new Command(LikeCurrentSongAsync);
        }
        public async void GetAnotherSong(string id)
        {
            currentSong = await repo.GetSong(id);
            SongImage = currentSong.Album.Images[0].Url;
            SongArtistImage = await repo.GetArtistImageAsync(currentSong.Artists[0].Id);
            SongName = currentSong.Name;
            AlbumName = currentSong.Album.Name;
            ArtistName = currentSong.Artists[0].Name;
            AudioDisplay.Source = currentSong.PreviewUrl;
            OnPropChanged(nameof(SongImage));
            OnPropChanged(nameof(SongArtistImage));
            OnPropChanged(nameof(SongName));
            OnPropChanged(nameof(AlbumName));
            OnPropChanged(nameof(ArtistName));
            OnPropChanged(nameof(AudioDisplay));
        }
        public async void PlayPauseSongAsync(object obj)
        {
            if (PlayPauseBtnSource == "play_icon.png")
            {
                PlayPauseBtnSource = "pause_icon.png";
                AudioDisplay.Play();
            }
            else
            {
                PlayPauseBtnSource = "play_icon.png";
                AudioDisplay.Pause();
            }
            OnPropChanged(nameof(PlayPauseBtnSource));
            OnPropChanged(nameof(AudioDisplay));
        }

        public async void LikeCurrentSongAsync(object obj)
        {
            WhiteList whiteList = new WhiteList
            {
                UserID = 1,
                SongID = currentSong.Id,
            };
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.LikeSongAsync(whiteList);
            }
            catch
            {
                checkIfSucces = false;
            }
            if (checkIfSucces)
            {
                await (Application.Current.MainPage).DisplayAlert("Succes", "The song has now been liked", "OK");
            }
            else
            {
                await (Application.Current.MainPage).DisplayAlert("Error", "The song couldn't be liked", "OK");
            }
        }
        public async void SkipCurrentSongAsync(object obj)
        {
            BlackList blackList = new BlackList
            {
                UserID = 1,
                SongID = currentSong.Id,
            };
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.SkipSongAsync(blackList);
            }
            catch
            {
                checkIfSucces = false;
            }
            if (checkIfSucces)
            {
                await (Application.Current.MainPage).DisplayAlert("Succes", "The song has now been skipped", "OK");
            }
            else
            {
                await (Application.Current.MainPage).DisplayAlert("Error", "The song couldn't be skipped", "OK");
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