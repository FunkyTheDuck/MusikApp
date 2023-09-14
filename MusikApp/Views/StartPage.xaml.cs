using MusikApp.ViewModels;

namespace MusikApp.Views;

public partial class StartPage : ContentPage
{
	public StartPage(StartPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}