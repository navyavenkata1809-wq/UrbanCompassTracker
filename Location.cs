using SQLite;
using System.Diagnostics;

namespace GeoTracker
{
    public class LocationRepository
    {
        private SQLiteAsyncConnection _conn;
        private const string DB_NAME = "geotracker_v1.db3";

        private async Task EnsureConnection()
        {
            if (_conn != null) return;

            var path = Path.Combine(FileSystem.AppDataDirectory, DB_NAME);
            _conn = new SQLiteAsyncConnection(path);
            await _conn.CreateTableAsync<GeoPoint>();
        }

        public async Task SavePointAsync(double latitude, double longitude)
        {
            await EnsureConnection();
            try
            {
                var point = new GeoPoint 
                { 
                    Lat = latitude, 
                    Lon = longitude, 
                    Timestamp = DateTime.UtcNow 
                };
                await _conn.InsertAsync(point);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Error: {ex.Message}");
            }
        }

        public async Task<List<GeoPoint>> GetHistoryAsync()
        {
            await EnsureConnection();
            return await _conn.Table<GeoPoint>().ToListAsync();
        }
    }
}
