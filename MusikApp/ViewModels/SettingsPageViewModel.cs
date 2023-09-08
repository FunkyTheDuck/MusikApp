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
        public SettingsPageViewModel()
        {
            currentChoosenGenre = new ObservableCollection<string>
            {
                "Rock",
                "EDM",
                "Country"
            };
            OnPropChanged(nameof(currentChoosenGenre));
        }

    }
}