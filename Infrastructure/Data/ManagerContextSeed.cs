using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ManagerContextSeed
    {
        public static async Task SeedAsync(ManagerContext context)
        {
            if (!context.Signals.Any())
            {
                var signalsData = File.ReadAllText("../Infrastructure/Data/SeedData/signals.json");
                var signals = JsonSerializer.Deserialize<List<Signal>>(signalsData);
                context.Signals.AddRange(signals);
            }

            if (context.ChangeTracker.HasChanges()) await context.saveChangesAsync();
        }
    }
}