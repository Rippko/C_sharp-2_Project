namespace WebApplication1
{
    public class ErrorHandler
    {
        private readonly IMyLogger _logger;
        public ErrorHandler(IMyLogger logger) 
        {
            this._logger = logger;
        }

        public async Task Handle(Exception ex)
        {
            await File.AppendAllTextAsync("log.txt", ex.Message + "\n" + ex.StackTrace);
        }
    }
}
