using AppRepository;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MusikApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IStartPageRepository, StartPageRepository>();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            bool isVirtual = DeviceInfo.Current.DeviceType switch
            { 
                DeviceType.Physical => false,
                DeviceType.Virtual => true,
                _ => false
            };
#if ANDROID && DEBUG
            if (isVirtual)
            {
                Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
                Platforms.Android.DangerousTrustProvider.Register();
            }
		    builder.Logging.AddDebug(); 
#endif



            return builder.Build();
        }
    }
}