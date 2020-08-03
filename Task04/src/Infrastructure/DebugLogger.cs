using Infrastructure.Interfaces;
using System.Diagnostics;

namespace Infrastructure
{
    public class DebugLogger : ILogger
    {
        public void Info(string message) => Debug.WriteLine(message);

        public void Error(string message) => Debug.WriteLine(message);
    }
}
