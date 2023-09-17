using MusikApp.ViewModels;

namespace MusikApp.Views;

public partial class Profil : ContentPage
{
	public Profil(ProfilViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected async override void OnAppearing()
    {
        string userId = await SecureStorage.Default.GetAsync("userId");
        if (string.IsNullOrEmpty(userId))
        {
            await Shell.Current.GoToAsync("//LoginPage");
            //await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}