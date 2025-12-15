using SQLite;

namespace GeoTracker
{
    [Table("TrackingHistory")]
    public class GeoPoint
    {
        [PrimaryKey, AutoIncrement]
        public int RecordId { get; set; }

        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
