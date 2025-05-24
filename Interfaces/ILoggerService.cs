namespace Ava.Shared.Interfaces;

public interface ILoggerService
{
    Task LogTraceAsync(string message);
    Task LogDebugAsync(string message);
    Task LogInfoAsync(string message);
    Task LogWarningAsync(string message);
    Task LogErrorAsync(string message);
    Task LogCriticalAsync(string message);
}
