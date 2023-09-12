using AppModels;
using AppRepository;
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
        public List<Genre> Genres { get; set; }
        public Genre SelectedGenre { get; set; }
        public ICommand SelectedGenreChanged { get; set; }
        public Color SelectedItemColor { get; set; }
        public ChooseGenrePageViewModel()
        {
            GenreRepo = new();
            GetGenres();
        }

        public async void GetGenres()
        {
            Genres = await GenreRepo.GetGenresAsync();
            OnPropChanged(nameof(Genres));
            SelectGenre();
        }


        public void SelectGenre()
        {
            //der skal sættes en api kald op for at kunne gå videre
            //SelectedGenre = //en api kald
        }
    }

}
