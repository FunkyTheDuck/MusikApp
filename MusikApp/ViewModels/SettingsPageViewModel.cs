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
    public class SettingsPageViewModel : BaseViewModels
    {
        public ObservableCollection<string> currentChoosenGenre { get; set; }
        public Settings Setting { get; set; }
        private SettingsPageRepository repo { get; set; }
        public SettingsPageViewModel()
        {
            currentChoosenGenre = new ObservableCollection<string>
            {
                "Rock",
                "EDM",
                "Country"
            };
            //GetUsersSettings();
            OnPropChanged(nameof(currentChoosenGenre));
        }
        private async void GetUsersSettings()
        {
            try
            {
                //Setting = await repo.GetUsersSettingsAsync(1);
            }
            catch
            {

            }
        }

    }
}