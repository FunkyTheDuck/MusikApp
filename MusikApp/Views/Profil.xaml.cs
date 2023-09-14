using MusikApp.ViewModels;

namespace MusikApp.Views;

public partial class Profil : ContentPage
{
	public Profil(ProfilViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
    public Profil()
    {
        InitializeComponent();
    }
}