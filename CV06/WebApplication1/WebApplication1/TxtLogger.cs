namespace WebApplication1
{
    public class TxtLogger : IMyLogger
    {
        public async Task Log(string message)
        {
            await File.AppendAllTextAsync("log.txt", message);
        }
    }
}
