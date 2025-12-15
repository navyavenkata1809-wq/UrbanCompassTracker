using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Maps; // Crucial import

namespace GeoTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // Using a slightly different builder pattern syntax
            var app = MauiApp.CreateBuilder();
            
            app.UseMauiApp<App>()
               .UseMauiMaps()
               .ConfigureFonts(f => f.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

#if DEBUG
            app.Logging.AddDebug();
#endif

            return app.Build();
        }
    }
}
