using MusikApp.Views;

namespace MusikApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new StartPage();
        }
    }
}