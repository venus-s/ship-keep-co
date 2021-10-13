using ShipKeepCo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ShipKeepCo.Infrastructure
{
    public static class ForumContextSeed
    {
        public static async Task SeedSampleDataAsync(ShipKeepCoContext context)
        {
            await SeedPricePerNightAsync(context);

            var locations = await SeedLocationsAsync(context);

            var voyages = await SeedVoyagesAsync(context);

            await SeedVoyagePointsAsync(context, voyages, locations);
        }

        public static async Task<Dictionary<string, Location>> SeedLocationsAsync(ShipKeepCoContext context)
        {
            if (!context.Locations.Any())
            {
                var locations = new List<Location>()
                {
                    new()
                    {
                        Name = "New York City",
                        Latitude = 40.7128,
                        Longitude = 74.0060
                    },
                    new()
                    {
                        Name = "Wilmington, NC",
                        Latitude = 34.2104,
                        Longitude = 77.8868
                    },
                    new()
                    {
                        Name = "Miami",
                        Latitude = 25.7617,
                        Longitude = 80.1918
                    },
                    new()
                    {
                        Name = "Cancun",
                        Latitude = 21.1619,
                        Longitude = 86.8515
                    },
                    new()
                    {
                        Name = "Montego Bay",
                        Latitude = 18.4762,
                        Longitude = 77.8939
                    },
                    new()
                    {
                        Name = "Parrot Bay",
                        Latitude = 18.3191,
                        Longitude = 64.7529
                    },
                    new()
                    {
                        Name = "Tuckers Town, Bermuda",
                        Latitude = 32.3326,
                        Longitude = 64.6873
                    },
                    new()
                    {
                        Name = "Atlantic City",
                        Latitude = 39.3643,
                        Longitude = 74.4229
                    },
                    new()
                    {
                        Name = "Halifax, NS",
                        Latitude = 44.6488,
                        Longitude = 63.5752
                    },
                    new()
                    {
                        Name = "Bar Harbor, ME",
                        Latitude = 44.3876,
                        Longitude = 68.2039
                    },
                    new()
                    {
                        Name = "Portland, ME",
                        Latitude = 43.6591,
                        Longitude = 70.2568
                    },
                    new()
                    {
                        Name = "Southampton, UK",
                        Latitude = 50.9097,
                        Longitude = 1.4044
                    },
                    new()
                    {
                        Name = "Cherbourg, France",
                        Latitude = 49.6337,
                        Longitude = 1.6221
                    },
                    new()
                    {
                        Name = "Bilbao, Spain",
                        Latitude = 43.2630,
                        Longitude = 2.9350
                    },
                    new()
                    {
                        Name = "Casablanca, Morocco",
                        Latitude = 33.5731,
                        Longitude = 7.5898
                    },
                    new()
                    {
                        Name = "Santa Cruz de Tenerife, Spain",
                        Latitude = 28.4636,
                        Longitude = 16.2518
                    },
                    new()
                    {
                        Name = "Ponta Delgada, Portugal",
                        Latitude = 37.7394,
                        Longitude = 25.6687
                    },
                    new()
                    {
                        Name = "Lisbon, Portugal",
                        Latitude = 38.7223,
                        Longitude = 9.1393
                    },
                    new()
                    {
                        Name = "Cobh, Ireland",
                        Latitude = 51.8503,
                        Longitude = 8.2943
                    },
                    new()
                    {
                        Name = "Galway, Ireland",
                        Latitude = 53.2707,
                        Longitude = 9.0568
                    },
                    new()
                    {
                        Name = "Bergen, Norway",
                        Latitude = 60.3913,
                        Longitude = 5.3221
                    },
                    new()
                    {
                        Name = "Edinburgh, Scotland",
                        Latitude = 55.9533,
                        Longitude = 3.1883
                    },
                    new()
                    {
                        Name = "Amsterdam, Netherlands",
                        Latitude = 52.3676,
                        Longitude = 4.9041
                    },
                };

                context.Locations.AddRange(locations);
                await context.SaveChangesAsync();

                return locations.ToDictionary(a => a.Name);
            }

            return context.Locations.ToDictionary(a => a.Name);
        }

        public static async Task SeedPricePerNightAsync(ShipKeepCoContext context)
        {
            if (!context.PricePerNights.Any())
            {
                var pricePerNight = new PricePerNight()
                {
                    Price = 249.99
                };

                context.PricePerNights.Add(pricePerNight);
                await context.SaveChangesAsync();
            }
        }

        public static async Task<Dictionary<string, Voyage>> SeedVoyagesAsync(ShipKeepCoContext context)
        {
            var voyages = Array.Empty<Voyage>();
            if (!context.Voyages.Any())
            {
                voyages = new Voyage[]
                {
                    new()
                    {
                        Name = "Americas A"
                    },
                    new()
                    {
                        Name = "Americas B"
                    },
                    new()
                    {
                        Name = "EU A"
                    },
                    new()
                    {
                        Name = "EU B"
                    }
                };

                context.Voyages.AddRange(voyages);

                await context.SaveChangesAsync();

                return voyages.ToDictionary(v => v.Name);
            }

            return context.Voyages.ToDictionary(a => a.Name);
        }

        public static async Task SeedVoyagePointsAsync(ShipKeepCoContext context, Dictionary<string, Voyage> voyages, Dictionary<string, Location> locations)
        {
            var voyagesArray = new Voyage[]
            {
                voyages["Americas A"],
                voyages["Americas B"],
                voyages["EU A"],
                voyages["EU B"]
            };

            if (!context.VoyagePoints.Any())
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"VoyagePoints.tsv");
                string[] lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    var entries = line.Split("\t");
                    var date = entries[0];
                    for (int i = 1; i < entries.Length; i++)
                    {
                        var locationName = entries[i];
                        if (string.IsNullOrWhiteSpace(locationName))
                        {
                            continue;
                        }

                        var location = locations[locationName];

                        var voyage = voyagesArray[i - 1];
                        var voyagePoint = new VoyagePoint()
                        {
                            Date = DateTime.Parse(date),
                            LocationId = location.LocationId,
                            VoyageId = voyage.VoyageId
                        };

                        context.VoyagePoints.Add(voyagePoint);
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
