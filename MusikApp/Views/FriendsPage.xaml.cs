namespace MusikApp.Views;

public partial class FriendsPage : ContentPage
{
	public FriendsPage()
	{
		InitializeComponent();
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