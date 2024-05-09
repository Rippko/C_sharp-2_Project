using System.Text.Json;

namespace WebApplication1
{
    public class JsonLogger : IMyLogger
    {
        public async Task Log(string message)
        {
            await File.WriteAllTextAsync("log.json", JsonSerializer.Serialize(new
            {
                Message = message,
                Added = DateTime.UtcNow
            }));
        }
    }
}
