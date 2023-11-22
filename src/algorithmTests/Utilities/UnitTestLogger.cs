using Xunit.Abstractions;

namespace algorithmTests;

public class UnitTestLogger : IAlgoLogger
{
    private readonly ITestOutputHelper testOutputHelper;

    public UnitTestLogger(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    public void Error(string message) => testOutputHelper.WriteLine($"[Error] {message}");

    public void Error(string format, params object[] args) => testOutputHelper.WriteLine($"[Error] {string.Format(format, args)}");

    public void Info(string message) => testOutputHelper.WriteLine($"[Info] {message}");

    public void Info(string format, params object[] args) => testOutputHelper.WriteLine($"[Info] {string.Format(format, args)}");

    public void Warn(string message) => testOutputHelper.WriteLine($"[Warn] {message}");

    public void Warn(string format, params object[] args) => testOutputHelper.WriteLine($"[Warn] {string.Format(format, args)}");
}
