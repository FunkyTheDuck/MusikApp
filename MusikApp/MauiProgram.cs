using AppRepository;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MusikApp.ViewModels;
using MusikApp.Views;

namespace MusikApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IStartPageRepository, StartPageRepository>();
            builder.Services.AddSingleton<IProfilPageRepository, ProfilPageRepository>();
            builder.Services.AddSingleton<ISettingsPageRepository, SettingsPageRepository>();
            builder.Services.AddScoped<ProfilViewModel>();
            builder.Services.AddScoped<Profil>();
            builder.Services.AddScoped<StartPageViewModel>();
            builder.Services.AddScoped<StartPage>();
            builder.Services.AddScoped<SettingsPageViewModel>();
            builder.Services.AddScoped<SettingsPage>();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if ANDROID && DEBUG
            Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
            Platforms.Android.DangerousTrustProvider.Register();
            builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}