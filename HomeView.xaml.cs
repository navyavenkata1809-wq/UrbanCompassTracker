using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace GeoTracker
{
    public partial class HomeView : ContentPage
    {
        private readonly LocationRepository _repo;

        public HomeView()
        {
            InitializeComponent();
            _repo = new LocationRepository();
        }

        private async void TrackButton_Clicked(object sender, EventArgs e)
        {
            // Request permissions using built-in MAUI essentials
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                InfoLabel.Text = "Access Denied";
                return;
            }

            InfoLabel.Text = "Acquiring Signal...";
            
            try
            {
                var gps = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.High));

                if (gps != null)
                {
                    await _repo.SavePointAsync(gps.Latitude, gps.Longitude);
                    InfoLabel.Text = $"Logged: {gps.Latitude:0.000}, {gps.Longitude:0.000}";

                    // Add visual marker immediately
                    UserMap.MapElements.Add(CreateHeatCircle(gps.Latitude, gps.Longitude));
                    
                    // Focus map
                    var span = MapSpan.FromCenterAndRadius(gps, Distance.FromMeters(500));
                    UserMap.MoveToRegion(span);
                }
            }
            catch
            {
                InfoLabel.Text = "Error getting location";
            }
        }

        private async void HeatmapButton_Clicked(object sender, EventArgs e)
        {
            var data = await _repo.GetHistoryAsync();
            InfoLabel.Text = $"Rendering layer: {data.Count} items";

            foreach (var item in data)
            {
                UserMap.MapElements.Add(CreateHeatCircle(item.Lat, item.Lon));
            }
        }

        // Helper method to keep code clean
        private Circle CreateHeatCircle(double lat, double lon) => new Circle
        {
            Center = new Location(lat, lon),
            Radius = Distance.FromMeters(60),
            StrokeColor = Colors.Blue,
            FillColor = Color.FromRgba(33, 150, 243, 100) // Blue with alpha
        };
    }
}
