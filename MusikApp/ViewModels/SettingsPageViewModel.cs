using AppModels;
using AppRepository;
using MusikApp.Views;
using Newtonsoft.Json;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModels
    {
        public ICommand LogoutButton { get; set; }
        public ICommand AddNewGenre { get; set; }
        public ObservableCollection<Genre> currentChoosenGenre { get; set; }
        public Settings Setting { get; set; }
        private ISettingsPageRepository repo { get; set; }

        #region Variable 
        private bool isDoingChanges = false;
        private double changeReleaseDate { get; set; }
        public double ChangeReleaseDate
        {
            get => changeReleaseDate;
            set
            {
                changeReleaseDate = value;
                ChangeReleaseDateAsync();
            }
        }
        private double changePopularity { get; set; }
        public double ChangePopularity
        {
            get => changePopularity;
            set
            {
                changePopularity = value;
                ChangePopularityAsync();
            }
        }
        private double changeEnergy { get; set; }
        public double ChangeEnergy
        {
            get => changeEnergy;
            set
            {
                changeEnergy = value;
                ChangeEnergyAsync();
            }
        }
        private double changeDanceability { get; set; }
        public double ChangeDanceability
        {
            get => changeDanceability;
            set
            {
                changeDanceability = value;
                ChangeDanceabilityAsync();
            }
        }
        private double changeDailyNotification { get; set; }
        public double ChangeDailyNotification
        {
            get => changeDailyNotification;
            set
            {
                changeDailyNotification = value;
                ChangeDailyNotificationAsync();
            }
        }
        #endregion
        public SettingsPageViewModel(ISettingsPageRepository repo)
        {
            this.repo = repo;
            repo = new SettingsPageRepository();
            AddNewGenre = new Command(ChooseNewGenre);
            LogoutButton = new Command(LogOutClickedAsync);
            GetUsersSettings();
            notificationTiming();
        }

        private async void GetUsersSettings()
        {
            try
            {
                Setting = await repo.GetUsersSettingsAsync(Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")));
            }
            catch
            {
                return;
            }
            if(Setting == null)
            {
                return;
            }
            currentChoosenGenre = new ObservableCollection<Genre>();
            foreach(string genre in Setting.ChangeGenre.Split(","))
            {
                currentChoosenGenre.Add(new Genre
                {
                    Name = genre
                });
            }
            OnPropChanged(nameof(currentChoosenGenre));
        }
        private async void ChooseNewGenre(object obj)
        {
            await Shell.Current.GoToAsync("//ChooseGenrePage");
        }
        private async void ChangeReleaseDateAsync()
        {
            if(!isDoingChanges)
            {
                isDoingChanges = true;
                Setting.HowNewTheMusicIs = (int)MathF.Round((float)ChangeReleaseDate);
                await repo.UpdateSettingsAsync(Setting);
                isDoingChanges = false;
            }
        }
        private async void ChangePopularityAsync()
        {
            if (!isDoingChanges)
            {
                isDoingChanges = true;
                Setting.Popularity = (int)MathF.Round((float)ChangePopularity);
                await repo.UpdateSettingsAsync(Setting);
                isDoingChanges = false;
            }
        }
        private async void ChangeEnergyAsync()
        {
            if (!isDoingChanges)
            {
                isDoingChanges = true;
                Setting.Energy = (int)MathF.Round((float)ChangeEnergy);
                await repo.UpdateSettingsAsync(Setting);
                isDoingChanges = false;
            }
        }
        private async void ChangeDanceabilityAsync()
        {
            if (!isDoingChanges)
            {
                isDoingChanges = true;
                Setting.Danceability = (int)MathF.Round((float)ChangeDanceability);
                await repo.UpdateSettingsAsync(Setting);
                isDoingChanges = false;
            }
        }
        private async void ChangeDailyNotificationAsync()
        {
            if (!isDoingChanges)
            {
                isDoingChanges = true;
                Setting.NotificationsAmount = (int)MathF.Round((float)ChangeDailyNotification);
                await repo.UpdateSettingsAsync(Setting);
                isDoingChanges = false;
            }
        }
        private async void LogOutClickedAsync()
        {
            SecureStorage.Default.Remove("userId");
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private void notificationTiming()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(60 * 1000); //one hour in milliseconds
            aTimer.Elapsed += new ElapsedEventHandler(SendNotifications);
            aTimer.Start();
        }
        public async void SendNotifications(object source, ElapsedEventArgs e)
        {
            DisplayedSong Song;
            Song = await repo.GetSongToNotification(Convert.ToInt32(await SecureStorage.Default.GetAsync("userId")));
            string json = JsonConvert.SerializeObject(Song);
            var request = new NotificationRequest
            {
                NotificationId = 1000,
                Title = "Har du lyst til at høre nyt musik?",
                Subtitle = "har du hørt?",
                ReturningData = json,
                Description = $"Hør {Song.SongName} fra {Song.ArtistName} lige nu",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    NotifyRepeatInterval = TimeSpan.FromMinutes(1),
                    RepeatType = NotificationRepeat.TimeInterval,
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
    }
}