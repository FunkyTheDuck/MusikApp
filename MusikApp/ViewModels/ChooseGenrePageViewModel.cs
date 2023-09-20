using AppModels;
using AppRepository;
using MusikApp.Views;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
            List<Genre> genres;
            genres = await GenreRepo.GetGenresAsync();

            foreach (Genre item in genres)
            {
                Genre genre = new Genre
                {
                    Name = item.Name
                };
                Genres.Add(item);
            }
            OnPropChanged(nameof(Genres));
        }

        public ObservableCollection<object> SelectedGenre { get; set; } = new(); //listen til selecteditems i collectionview

        public ICommand SelectedGenreChanged { get; set; } //commanden der er ved constructoren som forbinder SelectGenre til ICommand der er sat til en knap i xaml

        private async void SelectGenre()
        {
            string idValue = await SecureStorage.GetAsync("userId");
            Settings settings;
            if (int.TryParse(idValue, out int integerValue))
            {
                 settings = await settingRepo.GetUsersSettingsAsync(integerValue);

                string genreseparated = string.Join(",", SelectedGenre.OfType<Genre>().Select(x=>x.Name));

                settings.ChangeGenre += $"{genreseparated}";
                await settingRepo.UpdateSettingsAsync(settings);
            } 
            await Shell.Current.GoToAsync("//StartPage");
        }
    }

}
