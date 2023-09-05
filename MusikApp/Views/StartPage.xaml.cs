namespace MusikApp.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void SearchClicked(object sender, EventArgs e)
    {
        
    }

    private void MainPageClicked(object sender, EventArgs e)
    {

    }

    private void ProfilClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Profil());
    }

    private void FriendsClicked(object sender, EventArgs e)
    {

    }

    private void SettingsClicked(object sender, EventArgs e)
    {

    }
}