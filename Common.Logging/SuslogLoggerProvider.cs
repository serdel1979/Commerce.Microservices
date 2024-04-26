using Microsoft.Extensions.Logging;

namespace Common.Logging
{
    public class SuslogLoggerProvider : ILoggerProvider
    {
        private string _host;
        private readonly Func<string, LogLevel, bool> _filter;
        private int _port;

        public SuslogLoggerProvider(string host, int port, Func<string, LogLevel, bool> filter)
        {
            this._host = host;
            this._port = port;
            this._filter = filter;
        }




        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
