using System.Reflection;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ManagerContextSeed
    {
        public static async Task SeedAsync(ManagerContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Signals.Any())
            {
                var signalsData = File.ReadAllText(path + @"/Data/SeedData/signals.json");
                var signals = JsonSerializer.Deserialize<List<Signal>>(signalsData);
                context.Signals.AddRange(signals);
            }

            if(!context.SignalProtocols.Any())
            {
                var signalProtocolsData = File.ReadAllText(path + @"/Data/SeedData/protocols.json");
                var signalProtocols = JsonSerializer.Deserialize<List<SignalProtocol>>(signalProtocolsData);
                context.SignalProtocols.AddRange(signalProtocols);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}