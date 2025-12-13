# Location Tracker & Heat Map (MAUI)

A .NET MAUI application that tracks the user's geolocation, stores the coordinates in a local SQLite database, and visualizes the path history as a heat map overlay.

## Features
- **Real-time Tracking:** Captures GPS coordinates every 5 seconds.
- **Data Persistence:** Uses SQLite to save location data locally.
- **Heat Map Visualization:** Renders historical data points as semi-transparent overlays on the map to visualize density and path.
- **Cross-Platform:** Built for Android and iOS using .NET MAUI.

## Getting Started

### Prerequisites
- Visual Studio 2022
- .NET 7.0 or 8.0 SDK
- Android Emulator or Physical Device

### Installation
1. Clone the repository.
2. Open `HeatMapTracker.sln` in Visual Studio.
3. Restore NuGet packages (`Microsoft.Maui.Controls.Maps`, `sqlite-net-pcl`).
4. Build and Run on your preferred emulator.

### Usage
1. Grant Location permissions when prompted.
2. Click **Start Tracking** to begin recording coordinates.
3. Click **Visualize Heat Map** to load data from the database and render the path on the map.
