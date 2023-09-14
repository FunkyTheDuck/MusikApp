using AppModels;
using CommunityToolkit.Maui.Views;

namespace MusikApp.Views;

public partial class ArtistPopUp : Popup
{
    private string linkToArtistSpotify;
	public ArtistPopUp(DisplayedArtist artist)
	{
		InitializeComponent();
		ArtistImage.Source = artist.ImageUrl;
        ArtistName.Text = artist.Name;
        linkToArtistSpotify = artist.LinkToSpotify;
    }

    private async void ArtistLink_Clicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri(linkToArtistSpotify);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch 
        {
            await (Application.Current.MainPage).DisplayAlert("ERROR", "Couldn't open the link", "OK");
        }
    }
}