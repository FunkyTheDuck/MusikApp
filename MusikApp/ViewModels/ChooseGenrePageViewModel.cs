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
    public class ChooseGenrePageViewModel : BaseViewModels
    {
        GenrePageRepository GenreRepo { get; set; }
        SettingsPageRepository settingRepo {  get; set; }
        public List<Genre> Genres { get; set; }
        public Genre SelectedGenre { get; set; }
        public ICommand SelectedGenreChanged { get; set; }
        public Color SelectedItemColor { get; set; }
        public ChooseGenrePageViewModel()
        {
            settingRepo = new SettingsPageRepository();
            GenreRepo = new();
            GetGenres();
            SelectedGenreChanged = new Command(SelectGenre);
        }

        public async void GetGenres()
        {
            Genres = await GenreRepo.GetGenresAsync();
            OnPropChanged(nameof(Genres));
        }


        private async void SelectGenre()
        {
            Settings settings = await settingRepo.GetUsersSettingsAsync(1);
            settings.ChangeGenre += $",{SelectedGenre.Name}";
            
            await settingRepo.UpdateSettingsAsync(settings);

            await Shell.Current.GoToAsync(nameof(SettingsPage), false);
        }
    }

}
