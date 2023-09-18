using AppModels;
using AppRepository;
using CommunityToolkit.Maui.Views;
using MusikApp.Views;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class StartPageViewModel : BaseViewModels
    {
        IStartPageRepository repo { get; set; }
        public ICommand PlayPauseSound { get; set; }
        public ICommand SkipSong { get; set; }
        public ICommand LikeSong { get; set; }
        public ICommand ArtistClicked { get; set; }
        public string PlayPauseBtnSource { get; set; }
        private string artistId { get; set; }
        public DisplayedSong currentSong { get; set; }
        List<DisplayedSong> songQueue { get; set; }
        public MediaElement AudioDisplay { get; set; }
        public StartPageViewModel(IStartPageRepository repo)
        {
            this.repo = repo;
            AudioDisplay = new MediaElement
            {
                Volume = 0.03,
                ShouldAutoPlay = false,
            };
            repo = new StartPageRepository();
            songQueue = new List<DisplayedSong>();
            LoadNewSongs(5, true);
            PlayPauseBtnSource = "play_icon.png";
            OnPropChanged(nameof(PlayPauseBtnSource));
            PlayPauseSound = new Command(PlayPauseSongAsync);
            SkipSong = new Command(SkipCurrentSongAsync);
            LikeSong = new Command(LikeCurrentSongAsync);
            ArtistClicked = new Command(ArtistClickedAsync);
        }
        
        private async void LoadNewSongs(int amount, bool firstCall)
        {
            List<DisplayedSong> New5Songs;
            try
            {
                New5Songs = await repo.GetListOfRecommendation(Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")), amount);
            }
            catch
            {
                New5Songs = new List<DisplayedSong>();
            }
            foreach (DisplayedSong song in New5Songs)
            {
                songQueue.Add(song);
            }
            if(firstCall)
            {
                await DisplayNewSong();

            }
        }
        public async Task DisplayNewSong()
        {
            if(songQueue.Count > 0)
            {
                try
                {
                    currentSong = songQueue.First();
                }
                catch
                {
                    return;
                }
                if(string.IsNullOrEmpty(currentSong.SongImage))
                {
                    currentSong.SongImage = "not_found.png";
                }
                if (!currentSong.IsPlayable || string.IsNullOrEmpty(currentSong.PreviewUrl))
                {
                    songQueue.RemoveAt(0);
                    OnPropChanged(nameof(currentSong));
                    return;
                }
                songQueue.RemoveAt(0);
                AudioDisplay.Source = currentSong.PreviewUrl;
                OnPropChanged(nameof(currentSong));
                OnPropChanged(nameof(AudioDisplay));
            }
            if(songQueue.Count <= 2)
            {
                LoadNewSongs(3, false);
            }
            AudioDisplay.Play();
            PlayPauseBtnSource = "pause_icon.png";
            OnPropChanged(nameof(PlayPauseBtnSource));
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
        }

        public async void LikeCurrentSongAsync(object obj)
        {
            WhiteList whiteList = new WhiteList
            {
                UserID = Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")),
                SongID = currentSong.Id,
                SongArtistId = currentSong.ArtistId,
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
                await DisplayNewSong();
            }
            else
            {
                await (Application.Current.MainPage).DisplayAlert("Error", "spotify:artist:4RqlUMU9O5BNUhsRaukbRZ", "OK");
            }
        }
        public async void SkipCurrentSongAsync(object obj)
        {
            BlackList blackList = new BlackList
            {
                UserID = Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")),
                SongID = currentSong.Id,
                SongArtistId= currentSong.ArtistId,
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
                await DisplayNewSong();
            }
            else
            {
                await (Application.Current.MainPage).DisplayAlert("Error", "The song couldn't be skipped", "OK");
            }
        }
        private async void ArtistClickedAsync(object obj)
        {
            DisplayedArtist clickedArtist = await repo.GetArtistAsync(currentSong.ArtistId);
            await (Application.Current.MainPage).ShowPopupAsync(new ArtistPopUp(clickedArtist));
        }
    }
}