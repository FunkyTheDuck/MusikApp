using AppModels;
using AppRepository;
using MusikApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModels
    {
        public ICommand AddNewGenre { get; set; }
        public ObservableCollection<Genre> currentChoosenGenre { get; set; }
        public Settings Setting { get; set; }
        private SettingsPageRepository repo { get; set; }
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
        public SettingsPageViewModel()
        {
            repo = new SettingsPageRepository();
            AddNewGenre = new Command(ChooseNewGenre);
            GetUsersSettings();
        }

        private async void GetUsersSettings()
        {
            try
            {
                Setting = await repo.GetUsersSettingsAsync(1);
            }
            catch
            {
                return;
            }
            if(Setting != null)
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
            //await Shell.Current.GoToAsync();
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
    }
}