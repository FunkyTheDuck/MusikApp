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
using static SpotifyAPI.Web.PlaylistRemoveItemsRequest;

namespace MusikApp.ViewModels
{
    public class ChooseGenrePageViewModel : BaseViewModels
    {
        GenrePageRepository GenreRepo { get; set; }
        SettingsPageRepository settingRepo {  get; set; }
        public ObservableCollection<Genre> Genres { get; set; }


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

        public ObservableCollection<object> SelectedGenre { get; set; } = new(); //listen til selecteditems i collectionview

        public ICommand SelectedGenreChanged { get; set; } //commanden der er ved constructoren som forbinder SelectGenre til ICommand der er sat til en knap i xaml

        private async void SelectGenre()
        {

            Settings settings = await settingRepo.GetUsersSettingsAsync(1);
            string genreseparated = string.Join(",", SelectedGenre);

                settings.ChangeGenre += $"{genreseparated}";
            


            await settingRepo.UpdateSettingsAsync(settings);

            await Shell.Current.GoToAsync(nameof(SettingsPage), false);
        }
    }

}
