
using Games.DAL.Data.Contexts;
using Games.DAL.Data.Models;
using System.Text.Json;

namespace GameOn.DAL.Data.DataSeed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            if (!appDbContext.Categories.Any())
            {
                var categoriesData = File.ReadAllText("../Games.DAL/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                if (categories?.Count > 0)
                {
                    foreach (var category in categories)
                    {
                        await appDbContext.Categories.AddAsync(category);
                    }
                    await appDbContext.SaveChangesAsync();
                }
            }

            if (!appDbContext.Devices.Any())
            {
                var devicesData = File.ReadAllText("../Games.DAL/Data/DataSeed/Devices.json");
                var devices = JsonSerializer.Deserialize<List<Device>>(devicesData);

                if (devices?.Count > 0)
                {
                    foreach (var device in devices)
                    {
                        await appDbContext.Devices.AddAsync(device);
                    }
                    await appDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
