using MusikApp.ViewModels;

namespace MusikApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
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