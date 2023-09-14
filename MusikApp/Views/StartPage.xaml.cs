using MusikApp.ViewModels;

namespace MusikApp.Views;

public partial class StartPage : ContentPage
{
    public StartPage(StartPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected async override void OnAppearing()
    {
        string userId = await SecureStorage.Default.GetAsync("userId");
        if (string.IsNullOrEmpty(userId))
        {
            //await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}